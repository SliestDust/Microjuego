using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class Bullet : MonoBehaviour
{
	public float speed = 10f;
	public float maxLifetime = 3f;
	public Vector3 targetVector;
	public float fuerza = 500f;
	public GameObject asteroidPrefab;
	private GameObject meteor;
	private Vector3 media;
	private Vector3 pendiente;

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
		if(collision.gameObject.transform.localScale.x > 0.3){
			pendiente = new Vector3(-gameObject.transform.position.y + collision.gameObject.transform.position.y,-gameObject.transform.position.x + collision.gameObject.transform.position.x, 0);
			media =   (gameObject.transform.position + collision.gameObject.transform.position)/2;
			pendiente.Normalize();
			meteor = Instantiate(asteroidPrefab, media - pendiente*1, Quaternion.identity);
			meteor.transform.localScale = new Vector3(0.2f,0.2f,0);
			meteor.GetComponent<Rigidbody>().AddForce(-pendiente * fuerza);
			meteor = Instantiate(asteroidPrefab, media + pendiente*1, Quaternion.identity);
			meteor.transform.localScale = new Vector3(0.2f,0.2f,0);
			meteor.GetComponent<Rigidbody>().AddForce(pendiente * fuerza);
		}
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
