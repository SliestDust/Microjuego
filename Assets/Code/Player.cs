using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustForce = 5f;
    public float rotationSpeed = 10f;

	private Rigidbody _rigid;


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
    }
}
