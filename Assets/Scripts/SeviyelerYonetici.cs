using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeviyelerYonetici : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] levelButtons;
    public int amountOfLevelButtons = 8;
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
     levelButtons[0].interactable =true;
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


    }
}
