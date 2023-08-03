using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeviyelerYonetici : MonoBehaviour
{
    // Start is called before the first frame update
   public static bool seviye1,seviye2,seviye3;
public Button seviye1_button,seviye2_button,seviye3_button;
    private void Start() {
    seviye1=true;
   }
   private void Update() {
    if(seviye2==true)
    {
        seviye2_button.interactable=true;
    }
     if(seviye3==true)
    {
        seviye3_button.interactable=true;
    }
   }
}
