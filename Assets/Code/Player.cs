using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 5f;
    public float rotationSpeed = 10f;
    public float xBorderLimit = 10f;
    public float yBorderLimit = 10f;

    private Rigidbody _rigid;
    public GameObject gun, bulletPrefab;

    public static int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    	_rigid = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
	var newPos = transform.position;
	if (newPos.x > xBorderLimit){
		newPos.x = -xBorderLimit+1;
	} else if (newPos.x < -xBorderLimit){
		newPos.x = xBorderLimit-1;
	} else if (newPos.y > yBorderLimit){
		newPos.y = -yBorderLimit+1;
	} else if (newPos.y < -yBorderLimit){
		newPos.y = yBorderLimit-1;
	}
	transform.position = newPos;
	float rotation = Input.GetAxis("Thrust") * Time.deltaTime;
	float thrust = Input.GetAxis("Rotation") * Time.deltaTime;
	Vector3 thrustDirection = transform.right;
	_rigid.AddForce(thrustDirection * thrust * thrustForce);
	transform.Rotate(Vector3.forward, -rotation * rotationSpeed);
	if (Input.GetKeyDown(KeyCode.Space) && !Pause.gameIsPaused){
		
		GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
                  if (bullet != null) {
                         bullet.transform.position = gun.transform.position;
                        bullet.transform.rotation = Quaternion.identity;
                           bullet.SetActive(true);      
                  }

		Bullet balaScript = bullet.GetComponent<Bullet>();
		balaScript.targetVector = transform.right;
	}
    }
    private void OnCollisionEnter(Collision collision){
	
    }
    private void OnTriggerEnter(Collider collision){
	    if(collision.gameObject.tag == "Enemy"){
		    score = 0;
		    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	    } else{
		    Debug.Log("He colisionado con otro...");
	    }
    }
}
