using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackleMove : MonoBehaviour
{
    private bool movingLeft;

    [SerializeField] private float _speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft == true)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
            if (transform.position.x <= -2) movingLeft = false;
        }
        else
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            if (transform.position.x >= 2) movingLeft = true;
        }
    }
}

