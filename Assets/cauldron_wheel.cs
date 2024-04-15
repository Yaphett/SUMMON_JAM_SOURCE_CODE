using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cauldron_wheel : MonoBehaviour
{
    // Define the three settings
    public enum CauldronSetting { Setting1, Setting2, Setting3 }
    public CauldronSetting currentSetting;

    void Start()
    {
        // Set the initial setting
        currentSetting = CauldronSetting.Setting1;
    }

    void Update()
    {
        // Check for player input to toggle between settings
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Toggle between settings
            ToggleSetting();
        }
    }

    void ToggleSetting()
    {
        // Toggle between the three settings
        switch (currentSetting)
        {
            case CauldronSetting.Setting1:
                currentSetting = CauldronSetting.Setting2;
                break;
            case CauldronSetting.Setting2:
                currentSetting = CauldronSetting.Setting3;
                break;
            case CauldronSetting.Setting3:
                currentSetting = CauldronSetting.Setting1;
                break;
        }

        // Update UI or perform actions based on the current setting
        Debug.Log("Current setting: " + currentSetting);
    }
}
