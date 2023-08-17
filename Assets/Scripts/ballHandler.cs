using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ballHandler : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    public static ballBounce ballBounce;
    public GameObject ballObject;
    public Button continue_button;
    public Button replay_button;
    [SerializeField] private Rigidbody2D pivot;
    [SerializeField] private float respawnDelay;
    [SerializeField] private float detachDelay;
    [SerializeField] private int ballCount;
    [SerializeField] public Text ballCountText;
    [SerializeField] public Text HealthText;
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
        ballCountText.text = ballCount.ToString();
        mainScreenText.text = "";


    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log("testDegisken222222 "+ballBounce.testDegisken);

        
        HealthText.text = GameData.gameLife.ToString()+" x❤️";

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
        DisableEnableReplayButton(false);
        if (GameData.gameLife > 0)
        {

            if (ballCount > 0)
            {
                ballCountText.text = (ballCount).ToString();
                GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
                currentBallRigidbody = ballInstance.GetComponent<Rigidbody2D>();
                currentBallSpringJoint = ballInstance.GetComponent<SpringJoint2D>();
                currentBallSpringJoint.connectedBody = pivot;
                ballCount = ballCount - 1;
                

                ////////
                




            }
            else
            {
                ballCount = 5;
                GameData.gameLife -= 1;
                Debug.Log("GameLife " + GameData.gameLife.ToString());
                ballCountText.text = (ballCount).ToString();
                GameObject ballInstance = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
                currentBallRigidbody = ballInstance.GetComponent<Rigidbody2D>();
                currentBallSpringJoint = ballInstance.GetComponent<SpringJoint2D>();
                currentBallSpringJoint.connectedBody = pivot;
                ballCount = ballCount - 1;
                
                
            }
            
        }
        else{
             mainScreenText.text = "GameOver";
        }


    }

    public void LevelCompleted()
    {
        mainScreenText.text = "Level Completed";
        continue_button.gameObject.SetActive(true);
        DisableEnableReplayButton(false);
    }

    public void GameOver()
    {
        mainScreenText.text = "Game Over";
        DisableEnableReplayButton(false);
    }

    private void LaunchBall()
    {


        currentBallRigidbody.isKinematic = false;
        currentBallRigidbody = null;  //top fırladıktan sonra tekrar dokununca kontrol edilemesin diye
        Pivot.okCizgisiCikabilirmi = false;

        Invoke(nameof(DetachBall), detachDelay);
        DisableEnableReplayButton(true);

        //araya delay eklenmeli ki top fırlasın ve sistem serbest kalsın yoksa top direkt düşüyor.

    }


    private void DetachBall()
    {
        currentBallSpringJoint.enabled = false; // fırlattıktan sonra topu tutan merkezden serbest bırakmak için kullanıldı.
        currentBallSpringJoint = null;// fırlattıktan sonra topu tutan merkezden serbest bırakmak için kullanıldı.
        ballBounce._cisimEkranDisinda=false;
    }

    public void DisableEnableReplayButton(bool check)
    {
        if(check)
        {
            replay_button.gameObject.SetActive(true);
        }
        else
        {
            replay_button.gameObject.SetActive(false);
        }
    }

     public void replayButtonFunction()
    {

        // Debug.Log(_cisimEkranDisinda);
         SpawnNewBall();
        Pivot.okCizgisiCikabilirmi = true;
        ballBounce._cisimEkranDisinda = true;

        ballObject = GameObject.FindGameObjectWithTag("ballTag");
        Destroy(ballObject);
        //Destroy(gameObject);
    }





}
