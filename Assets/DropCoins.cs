using UnityEngine;
using System.Collections;

public class DropCoins : MonoBehaviour {
	
	public GameObject coinSprayerPf;
	bool gotHit;
	
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.CompareTag("Burger") && !gotHit)
		{
			gotHit = true;
			Instantiate(coinSprayerPf, 
			            transform.position, 
			            Quaternion.identity);
		}
	}
}
