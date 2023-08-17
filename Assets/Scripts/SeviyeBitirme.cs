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

    public void levelEkranınaGit()
    {

        SceneManager.LoadScene(1);

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
    public void seviye1bitir()
    {
        SeviyelerYonetici.seviye2 = true;
        Pivot.okCizgisiCikabilirmi=true;
        SceneManager.LoadScene(1);

    }
    public void seviye2bitir()
    {
        SeviyelerYonetici.seviye3 = true;
        Pivot.okCizgisiCikabilirmi=true;
        SceneManager.LoadScene(1);

    }

      public void seviye3bitir()
    {
        SeviyelerYonetici.seviye4 = true;
        Pivot.okCizgisiCikabilirmi=true;
        SceneManager.LoadScene(1);

    }
    public void seviye4bitir()
    {
        SeviyelerYonetici.seviye5 = true;
        Pivot.okCizgisiCikabilirmi=true;
        SceneManager.LoadScene(1);

    }
    public void seviye5bitir()
    {
        SeviyelerYonetici.seviye6 = true;
        Pivot.okCizgisiCikabilirmi = true;
        SceneManager.LoadScene(1);

    }
    public void seviye6bitir()
    {
        SeviyelerYonetici.seviye6 = true;
        Pivot.okCizgisiCikabilirmi = true;
        SceneManager.LoadScene(1);

    }
}
