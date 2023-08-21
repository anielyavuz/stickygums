using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pivot : MonoBehaviour
{
    private LineRenderer lr;
    Vector2 throwVector;
    Vector3 mousePos;
    Vector2 distance;
    bool okCizildiMi = false;
    public static bool okCizgisiCikabilirmi = true; //top fırlatıldıktan sonra okun tekrar çıkmaması için
                                      // Start is called before the first frame update
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
      


            if (okCizildiMi)
            {
                if (!Touchscreen.current.primaryTouch.press.isPressed)
                {
                    lr.enabled = false;
                }
            }
              if (okCizgisiCikabilirmi)
        {
            if (Touchscreen.current.primaryTouch.press.isPressed)
            {
                OkCiz();
            }
        }
    }

    private void OkCiz()
    {
        CalculateThrowVector();
        SetArrow();
        okCizildiMi = true;
    }

    void CalculateThrowVector()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0f, -3.38f, 0f);
        Vector2 distance = mousePos - new Vector3(0f, 0f, 0f);
        throwVector = -distance.normalized * 100;
    }

    void SetArrow()
    {
        lr.positionCount = 2;
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, throwVector.normalized * 5);
        lr.enabled = true;
    }
}
