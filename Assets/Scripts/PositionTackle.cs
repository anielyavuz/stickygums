using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTackle : MonoBehaviour
{
    public GameObject Tackle;

    // Start is called before the first frame update
    void Start()
    {
        Tackle.transform.position = new Vector3(Screen.width * Tackle.transform.position.x / 1440, Screen.height * Tackle.transform.position.y / 3040, 0);
        Tackle.transform.localScale = new Vector3(Screen.width * Tackle.transform.localScale.x / 1440,Screen.height * Tackle.transform.localScale.y / 3040, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
