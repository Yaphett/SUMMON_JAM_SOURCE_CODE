using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gatherable : MonoBehaviour
{
    public int hp;
    public bool rat, skull;
    public float gatherRadius = 3f; // Radius within which the gatherable object can be gathered
    public float gatherTime = 2f; // Time it takes to gather the object
    public GameObject loadingBar; // Reference to the loading bar GameObject
    private currencyHandler ch;
    //public audiomanager am;

    private bool isGathering = false; // Flag to track if the player is currently gathering
    private float gatherProgress = 0f; // Current progress of the gathering process
    private Vector3 initialScale; // Initial scale of the loading bar
    private GameObject player; // Reference to the player GameObject

    private void Start()
    {
        ch = GameObject.FindGameObjectWithTag("GAMEMASTER").GetComponent<currencyHandler>();
        //am = GameObject.FindGameObjectWithTag("AUDIOMANAGER").GetComponent<audiomanager>();
        // Store the initial scale of the loading bar
        initialScale = loadingBar.transform.localScale;

        float randomVariance = Random.Range(0f, .5f);
        gatherTime = gatherTime -= randomVariance;
        // Hide the loading bar initially
        loadingBar.SetActive(false);

        // Find the player GameObject by tag (make sure your player GameObject has the appropriate tag)
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Check if the player presses the spacebar
        if (Input.GetKeyDown(KeyCode.Space) && !isGathering)
        {
            // Gather all nearby gatherable objects
            GatherNearbyObjects();
        }
    }

    private void GatherNearbyObjects()
    {
        // Get all gatherable objects in the scene
        GameObject[] gatherableObjects = GameObject.FindGameObjectsWithTag("Gatherable");

        // Loop through all gatherable objects
        foreach (GameObject obj in gatherableObjects)
        {
            // Check if the object is within the gather radius of the player
            if (Vector3.Distance(player.transform.position, obj.transform.position) <= gatherRadius)
            {
                // Start gathering process for the object if it's not already gathering
                gatherable gatherable = obj.GetComponent<gatherable>();
                if (gatherable != null && !gatherable.isGathering)
                {
                    gatherable.StartGathering();
                }
            }
        }
    }

    public void StartGathering()
    {
        // Set flag to indicate gathering is in progress
        isGathering = true;
        gatherProgress = 0f;

        // Show the loading bar
        loadingBar.SetActive(true);

        // Start coroutine to simulate gathering process
        StartCoroutine(Gather());
    }

    private IEnumerator Gather()
    {
        // Loop until gathering is complete
        while (gatherProgress < 1f)
        {
            // Increment gather progress over time
            gatherProgress += Time.deltaTime / gatherTime;

            // Update the scale of the loading bar to represent progress
            loadingBar.transform.localScale = new Vector3(initialScale.x * gatherProgress, initialScale.y, initialScale.z);

            yield return null;
        }



        // Gather process complete
        isGathering = false;
        Debug.Log("Gathering complete!");
        audiomanager.instance.PlaySoundEffect(0);
        // Hide the loading bar
        loadingBar.SetActive(false);
        hp -= 1;

        if (rat)
        {
            ch.craftingMats += 1;
        }
        if(skull)
        {
            ch.craftingMats += 1;
        }
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }

    }