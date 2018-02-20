using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public static GameController instance;
	public float scrollSpeed = -1.5f;

	public GameObject gameOverText;
	public bool gameOver = false;

	private int score = 0;
	public Text scoreText;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	void Start ()
	{
		
	}

	void Update ()
	{
		if (gameOver && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void ScoredBird ()
	{
		if (gameOver)
			return;
		score++;
		scoreText.text = "Score: " + score.ToString ();
	}

	public void DiedBird ()
	{
		gameOverText.SetActive (true);
		gameOver = true;
	}
}
