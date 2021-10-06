using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{
    public AudioClip coinSound;
    public TMP_Text coinText;
    public int coinCount;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Coin")){
            AudioSource.PlayClipAtPoint(coinSound,other.transform.position);
            coinCount++;
            coinText.text = coinCount.ToString();
            Destroy(other.gameObject);
        }
    }

    public void IncreaseCoin(int coin){
        coinCount += coin;
        coinText.text = coinCount.ToString();
    }

}
