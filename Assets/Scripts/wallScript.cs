using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    private Camera mainCamera;   
    // Start is called before the first frame update
    void Start()
    {
        mainCamera=Camera.main ;
        SpawnNewWall();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
   private void  SpawnNewWall()
     {
        //Sağ duvar
        Vector3 screenPosition=  new Vector3(Screen.width,Screen.height/2,10);
        Vector3 worldPosition=    mainCamera.ScreenToWorldPoint(screenPosition);
        transform.position= new Vector3(worldPosition.x,worldPosition.y,transform.position.z);
        GameObject ballInstance= Instantiate(wallPrefab, worldPosition,Quaternion.identity);

        //Sol duvar
        Vector3 screenPosition2=  new Vector3(0,Screen.height/2,10);
        Vector3 worldPosition2=    mainCamera.ScreenToWorldPoint(screenPosition2);
        transform.position= new Vector3(worldPosition2.x,worldPosition2.y,transform.position.z);
        GameObject ballInstance2= Instantiate(wallPrefab, worldPosition2,Quaternion.identity);

        //Yukarı Duvar
        Vector3 screenPosition3=  new Vector3(Screen.width/2,Screen.height,10);
        Vector3 worldPosition3=    mainCamera.ScreenToWorldPoint(screenPosition3);
        transform.position= new Vector3(worldPosition3.x,worldPosition3.y,transform.position.z);
        GameObject ballInstance3= Instantiate(wallPrefab, worldPosition3,transform.rotation * Quaternion.Euler (0f, 0f, 90f));

        
      
     }
}
