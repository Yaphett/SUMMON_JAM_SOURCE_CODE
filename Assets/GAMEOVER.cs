using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GAMEOVER : MonoBehaviour
{
    public GameObject sumCircle, retryUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void RestartScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        if(sumCircle == null)
        {
            retryUI.SetActive(true);
        }
    }
}
