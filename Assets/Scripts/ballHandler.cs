using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ballHandler : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    public Button continue_button;
    [SerializeField] private Rigidbody2D pivot;
    [SerializeField] private float respawnDelay;
    [SerializeField] private float detachDelay;
    [SerializeField] private int ballCount;
    [SerializeField] public Text ballCountText;
    [SerializeField] public Text mainScreenText;
    private Rigidbody2D currentBallRigidbody;
    private SpringJoint2D currentBallSpringJoint;
    private Camera mainCamera;
    public bool isDragging;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        SpawnNewBall();
        // Debug.Log("testDegisken "+ballBounce.testDegisken);
    }

    void Awake()
    {
      ballCountText.text= ballCount.ToString(); 
      mainScreenText.text="";


    }

    // Update is called once per frame
    void Update()
    {   
        
        // Debug.Log("testDegisken222222 "+ballBounce.testDegisken);
      
       
        

        if (currentBallRigidbody == null)
        {
            return;
        }
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (isDragging)
            {
                LaunchBall();
            }
            isDragging = false;

            return;
        }

        isDragging = true;
        currentBallRigidbody.isKinematic = true;
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
        currentBallRigidbody.position = worldPosition;


    }


    public void SpawnNewBall()
    {
        if(ballCount>0)
        {
        ballCountText.text= (ballCount).ToString(); 
        GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
        currentBallRigidbody = ballInstance.GetComponent<Rigidbody2D>();
        currentBallSpringJoint = ballInstance.GetComponent<SpringJoint2D>();
        currentBallSpringJoint.connectedBody = pivot;
        ballCount=ballCount-1; 
        }
        else{
            mainScreenText.text="GameOver";
        }
       
    }

    public void LevelCompleted(){
        mainScreenText.text="Level Completed";
        continue_button.gameObject.SetActive(true);
    }

     public void GameOver(){
        mainScreenText.text="Game Over";
    }

    private void LaunchBall()
    {
        currentBallRigidbody.isKinematic = false;
        currentBallRigidbody = null;  //top fırladıktan sonra tekrar dokununca kontrol edilemesin diye
    
        Invoke(nameof(DetachBall), detachDelay);

        //araya delay eklenmeli ki top fırlasın ve sistem serbest kalsın yoksa top direkt düşüyor.

    }


    private void DetachBall()
    {
        currentBallSpringJoint.enabled = false; // fırlattıktan sonra topu tutan merkezden serbest bırakmak için kullanıldı.
        currentBallSpringJoint = null;// fırlattıktan sonra topu tutan merkezden serbest bırakmak için kullanıldı.

    }
    



}
