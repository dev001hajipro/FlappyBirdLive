using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		// hit bird.
		if (other.GetComponent<Bird> () != null) {
			GameController.instance.ScoredBird ();
		}
	}
}
