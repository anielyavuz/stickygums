using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBounce : MonoBehaviour
{
    ballHandler ballHandler;
    

    // Start is called before the first frame update
    private Rigidbody2D rb;
    public bool _cisimEkranDisinda = false;
    

    Vector3 lastVelocity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
 
      
    }

     void Start()
    {
        Invoke(nameof(BallAssing), 1);
 
    }
    public void BallAssing(){
        ballHandler=GameObject.FindGameObjectWithTag("BallHandlerTag").GetComponent<ballHandler>();

    }


    // Update is called once per frame
    void Update()
    {
        
        lastVelocity = rb.velocity;
      

        Invoke(nameof(ballDroped), 2);

    }


    private void ballDroped()
    {
        if (!_cisimEkranDisinda)
        {
            if (!GetComponent<Renderer>().isVisible)
            {
                

                Debug.Log("cisim kayboldu");
                ballHandler.SpawnNewBall();
                _cisimEkranDisinda = true;
                
                Destroy(gameObject);
                
                //Whatever you want to do here
            }
        }


    }
    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "targetTag")
        {
            //hedefe çarptıysa durmasını sağlıyor
            Debug.Log("Dokundu");

            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(0f, 0f);
            ballHandler.LevelCompleted();
        }

        else
        {
            //çarpılan nesneden sekmesini sağlıyor
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);
        }



    }
}
