using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currencyHandler : MonoBehaviour
{
    public int craftingMats;
    public TextMeshProUGUI craftingMatsText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCraftingMatsText();
    }

    // Update is called once per frame
    void Update()
    {
        if (craftingMats < 0)
        {
            craftingMats = 0;
        }

        UpdateCraftingMatsText();
    }

    void UpdateCraftingMatsText()
    {
        // Update the TextMeshProUGUI component with the crafting materials divided by 3
        craftingMatsText.text = (craftingMats / 3).ToString();
    }
}