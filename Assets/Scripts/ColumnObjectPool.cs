using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SocialPlatforms;

public class ColumnObjectPool : MonoBehaviour
{

	public int poolSize = 5;
	public GameObject columnPrefab;
	private GameObject[] columns;
	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);

	public float spawnRate = 4f;
	private float timeSinceLastSpawned;

	public float columnMinY = -3.5f;
	public float columnMaxY = 1f;

	private int currentColumn = 0;
	private const float spawnXPosition = 10f;

	void Start ()
	{
		//columns = new GameObject[poolSize];
		//columns = columns.Select (i => (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity)).ToArray ();
		//columns = (from i in Enumerable.Range (0, poolSize)
		//           select (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity)).ToArray ();
		columns = Enumerable.Range (0, poolSize)
			.Select (i => (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity))
			.ToArray ();

	}

	void Update ()
	{
		timeSinceLastSpawned += Time.deltaTime;
		if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate) {
			timeSinceLastSpawned = 0;
			float spawnYPosition = Random.Range (columnMinY, columnMaxY);
			columns [currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
			/*
			currentColumn++;
			if (currentColumn >= poolSize)
				currentColumn = 0;
				*/
			currentColumn = ++currentColumn % poolSize;
		}
	}
}
