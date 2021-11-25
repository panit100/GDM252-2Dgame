using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable){
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
        }else{
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
        }
    }
}
