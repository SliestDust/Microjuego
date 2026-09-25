using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustForce = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody _rigid;
    public GameObject gun, bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    	_rigid = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
	float rotation = Input.GetAxis("Thrust") * Time.deltaTime;
	float thrust = Input.GetAxis("Rotation") * Time.deltaTime;
	Vector3 thrustDirection = transform.right;
	_rigid.AddForce(thrustDirection * thrust * thrustForce);
	transform.Rotate(Vector3.forward, -rotation * rotationSpeed);
	if (Input.GetKeyDown(KeyCode.Space)){
		GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
		Bullet balaScript = bullet.GetComponent<Bullet>();
		balaScript.targetVector = transform.right;
	}
    }
    private void OnCollisionEnter(Collision collision){
	
    }
    private void OnTriggerEnter(Collider collision){
	    SceneManager.LoadScene(SceneManager.getActiveScene().name);
    }
}
