using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public float upForce = 230f;
	private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator anim;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}

	void Update ()
	{
		if (!isDead) { // alive
			if (Input.GetMouseButtonDown (0)) { // left click
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (Vector2.up * upForce);
				anim.SetTrigger ("Flap");
				Debug.Log ("Do GetMouseButton");
			}
		}
	}

	void FixedUpdate ()
	{
		if (rb2d.velocity.y > 0) {
			float angle = Mathf.Lerp (0, 90, rb2d.velocity.y / 7);
			transform.rotation = Quaternion.Euler (0, 0, angle);
		} else if (rb2d.velocity.y <= 0) {
			float angle = Mathf.Lerp (0, -90, -rb2d.velocity.y / 7);
			transform.rotation = Quaternion.Euler (0, 0, angle);
		}
	}

	void OnCollisionEnter2D (Collision2D collision2D)
	{
		rb2d.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger ("Die");
		GameController.instance.DiedBird ();
	}
}
