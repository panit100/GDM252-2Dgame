using UnityEngine;
using System.Collections;

public class CoinSprayer : MonoBehaviour {

	public int numCoins = 10;
	public GameObject coinPrefab;
	public float offSetRange = 1.5f;

	void Start () {
		SpawnCoins();
	}

	void SpawnCoins(){
		for (int i = 0; i < numCoins; i++){
			Vector2 spawnOffset = 
				new Vector2 (Random.Range(-offSetRange, offSetRange), 
				             Random.Range(-offSetRange, offSetRange));
			Instantiate(coinPrefab, 
			            (Vector2)transform.position + spawnOffset, 
			            Quaternion.identity);
		}
	}

	void OnTriggerExit2D (Collider2D col){
		if (col.CompareTag("Player")){
			//disable PointEffector. If enabled, it will effect player because it is still on the scene.
			gameObject.GetComponent<PointEffector2D>().enabled = false;
		}
	}
}
