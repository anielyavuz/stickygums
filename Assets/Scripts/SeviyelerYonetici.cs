using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeviyelerYonetici : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] levelButtons;
    public int amountOfLevelButtons = 6;
    public static bool seviye1, seviye2, seviye3, seviye4, seviye5, seviye6;
    public Button seviye1_button, seviye2_button, seviye3_button, seviye4_button, seviye5_button, seviye6_button;


    public static bool yeniLevelInfo=false;
    public static int yeniLevelID=1;
    private void Awake()
    {
        levelButtons = new Button[amountOfLevelButtons];
        for (var i = 1; i <= amountOfLevelButtons; i++)
        {
            
            Button _currentlevelButton = GameObject.Find("Button" + i).GetComponent<Button>(); // This is line 37
            
            levelButtons[i-1] = _currentlevelButton; // This is line 38

        }

    }

    private void Start()
    {
        seviye1 = true;
    }
    private void Update()
    {
        if(yeniLevelInfo)
        {
               Debug.Log(yeniLevelInfo);
               Debug.Log(yeniLevelID);
               for (int i = 0; i <= yeniLevelID; i++)
               {
                levelButtons[i].interactable =true;
               }
            

            yeniLevelInfo=false;
        }


        // if (seviye2 == true)
        // {
        //     seviye2_button.interactable = true;
        // }
        // if (seviye3 == true)
        // {
        //     seviye3_button.interactable = true;
        // }
        // if (seviye4 == true)
        // {
        //     seviye4_button.interactable = true;
        //     //
        // }

        // if (seviye5 == true)
        // {
        //     seviye5_button.interactable = true;
        // }
        // if (seviye6 == true)
        // {
        //     seviye6_button.interactable = true;
        // }
    }
}
