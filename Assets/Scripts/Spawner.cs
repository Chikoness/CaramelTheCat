using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject[] spawnMobs;
    public Transform point1;
    public Transform point2;
    public int maxSpawns = 3;

    public static int spawned = 0;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnControl());
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    IEnumerator SpawnControl () //mob spawner control settings
    {
        while (true)
        {
            if (GameManager.GameState == State.Play)
            {
                if (spawned < maxSpawns)
                {
                    GameObject spawnedObject = Instantiate<GameObject>(spawnMobs[Random.Range(0, spawnMobs.Length)]);
                    spawnedObject.transform.position 
                        = new Vector2(Random.Range(point1.transform.position.x, point2.transform.position.x), point1.transform.position.y);
                    spawned++;
                }

                yield return new WaitForSeconds(Random.Range(0, 0.5f));
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
