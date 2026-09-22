using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;
	public float maxLifetime = 3f;
	public Vector3 targetVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, maxLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }
}
