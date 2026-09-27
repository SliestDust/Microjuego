using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 10f;
    public float spawnRateIncrement = 1f;
    public float xLimit;
    public float maxTimeLife = 3f;
    private float spawnNext = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Time.time > spawnNext) {
	       spawnNext = Time.time + 60 / spawnRatePerMinute;

	       spawnRatePerMinute += spawnRateIncrement;

	       float rand = Random.Range(-xLimit, xLimit);
	       Vector2 spawnPosition = new Vector2(rand, 8f);
       	       GameObject meteor = Instantiate(asteroidPrefab, (Vector3) spawnPosition, Quaternion.identity);
	       Destroy(meteor, maxTimeLife);
	}
    }
	       /*GameObject meteor = ObjectPoolM.SharedInstance.GetPooledObject(); 
		  if (meteor != null) {
			 meteor.transform.position = spawnPosition;
 			   meteor.transform.rotation = Quaternion.identity;
 			   meteor.SetActive(true);
			
	       		coroutine = Deactivate(meteor);
		  	StartCoroutine(coroutine);
		  }
       	}
    }
    private IEnumerator Deactivate(GameObject meteor){
	    yield return new WaitForSeconds(maxTimeLife);
	    meteor.SetActive(false);
    }*/
   /* public void Spawn(Vector3 pos, Quaternion rotation, float speed){
       	       GameObject meteor = Instantiate(asteroidPrefab, (Vector3) pos, Quaternion.identity);
	       Destroy(meteor, maxTimeLife);
    }*/
}
