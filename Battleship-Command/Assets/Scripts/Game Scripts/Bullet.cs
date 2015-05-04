using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Vector2 origin;
    public Vector2 direction;
    public Rigidbody2D rigidBody;
    public float speed;
    public float distanceTravelled;

	public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        speed = 0.8f;
        distanceTravelled = 0f;
	}
	
	public void Update()
    {
        rigidBody.MovePosition(rigidBody.position + speed * direction);
        distanceTravelled = (rigidBody.position - origin).magnitude;

        if (distanceTravelled > 10)
        {
            Destroy(this.transform.gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(GameObject.Find("Player")))
        {
            Destroy(this.transform.gameObject);
        }
    }
}
