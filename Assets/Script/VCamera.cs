using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCamera : MonoBehaviour
{

    public CinemachineVirtualCamera vCam1,vCam2,vCam3;
    public GameObject ready,go;
    
    float time = 0;
    private void Start() {
    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 1){
            vCam3.gameObject.SetActive(false);
            
        }
        if(time >= 2){
            ready.SetActive(false);
            go.SetActive(true);
        }

        if(time >= 4){
            go.SetActive(false);
        }

        // if(Input.GetKeyDown(KeyCode.Z)){
        //     vCam1.gameObject.SetActive(true);
        //     vCam2.gameObject.SetActive(false);    
        // }else if(Input.GetKeyDown(KeyCode.X)){
        //     vCam1.gameObject.SetActive(false);
        //     vCam2.gameObject.SetActive(true);   
        // }
        
    }
}
