using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeviyeBitirme : MonoBehaviour
{
    // Start is called before the first frame update

    // public void replayButtonClicked(){
    //     ballHandler.replayButtonFunction();
    // }

    public void mevcutLevelBitir()
    {
        var sceneID = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneID);
        Pivot.okCizgisiCikabilirmi=true;
        SeviyelerYonetici.yeniLevelInfo=true;
        SeviyelerYonetici.yeniLevelID=sceneID-1; //Mevcut scene ID'in 1 üstü olması için +1 eklendi, SeviyelerYonetici altındaki array'in ilgili elemanına denk gelmesi için 2 çıkarıldı ve sonuç -1 oldu. 
        SceneManager.LoadScene(1);
    }
    public void levelEkranınaGit()
    {

        SceneManager.LoadScene(1);

    }

    public void seviyeBasla() 
    
    {
        
    }

    public void seviye1basla()
    {

        SceneManager.LoadScene(2);

    }
    public void seviye2basla()
    {
        SceneManager.LoadScene(3);

    }
    public void seviye3basla()
    {

        SceneManager.LoadScene(4);

    }
 public void seviye4basla()
    {

        SceneManager.LoadScene(5);

    }
    public void seviye5basla()
    {

        SceneManager.LoadScene(6);

    }
    public void seviye6basla()
    {

        SceneManager.LoadScene(7);

    }
    public void seviye7basla()
    {

        SceneManager.LoadScene(8);

    }
    // public void seviye1bitir()
    // {
    //     SeviyelerYonetici.seviye2 = true;
    //     Pivot.okCizgisiCikabilirmi=true;
    //     SceneManager.LoadScene(1);

    // }

}
