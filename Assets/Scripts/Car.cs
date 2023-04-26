using UnityEngine;

public class Car : MonoBehaviour {

	public Rigidbody2D rb;

	public static float minSpeed;
	public static float maxSpeed;

	float speed = 1f;

	void Start ()
	{
		speed = Random.Range(minSpeed, maxSpeed);
	}

	void FixedUpdate () {
		Vector2 forward = new Vector2(transform.right.x, transform.right.y);
		rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
	}

}
