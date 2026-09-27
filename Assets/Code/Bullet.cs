using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class Bullet : MonoBehaviour
{
	public float speed = 10f;
	public float maxLifetime = 3f;
	public Vector3 targetVector;
	public EnemySpawner enemySpawner;
  //º      private IEnumerator corutina;
	private float time = 0f;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    public void Deactivate(GameObject meteor){
           // yield return new WaitForSeconds(maxLifetime);
            meteor.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
	time += Time.deltaTime;
	if(time > maxLifetime){
		time = 0f;
		Deactivate(gameObject);
	}
    }
    private void OnCollisionEnter(Collision collision){
	if(collision.gameObject.CompareTag("Enemy")){
		IncreaseScore();
		//if(collision.gameObject.transform.scale.x > 0.1){
		//	enemySpawner.Spawn(collision.gameObject.transform.position, Quaternion.identity, 0);
		//}
		Destroy(collision.gameObject);
		time = 0f;
		gameObject.SetActive(false);
	}
    }
	private void IncreaseScore(){
		Player.score++;
		Debug.Log(Player.score);
		UpdateScoreText();
	}
	private void UpdateScoreText(){
		GameObject go = GameObject.FindGameObjectWithTag("UI");
		go.GetComponent<TextMeshProUGUI>().text = "Puntos : " + Player.score;
	}
}
