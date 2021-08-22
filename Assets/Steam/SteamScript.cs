using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;
        StartCoroutine(DelayAnimation());
    }

    IEnumerator DelayAnimation(){
        float random = Random.Range(0,4.5f);
        yield return new WaitForSeconds(random);
        GetComponent<Animator>().enabled = true;
    }
}
