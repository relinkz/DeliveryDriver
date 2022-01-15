using UnityEngine;

public class Driver : MonoBehaviour
{
	[SerializeField] float handlingSpeed = 100.0f;
	[SerializeField] float baseSpeed = 4.0f;
	[SerializeField] float slowSpeed = 4.0f;
	[SerializeField] float boostSpeed = 4.0f;

	float collitionTimer = 0;
	float triggerTimer = 0;
	const float TRIGGER_LENGTH = 3.0f;


	void Update()
	{
		HandleMovement();
	}

	void HandleMovement()
	{
		var progressiveSlowSpeed = slowSpeed;
		var progressiveBoostSpeed = boostSpeed;

		if (collitionTimer > 0.0f)
		{
			collitionTimer -= Time.deltaTime;
			progressiveSlowSpeed *= collitionTimer;
		}
		if (triggerTimer > 0.0f)
		{
			triggerTimer -= Time.deltaTime;
			progressiveBoostSpeed *= triggerTimer;
		}

		var movementSpeed = baseSpeed + progressiveBoostSpeed - progressiveSlowSpeed;
		var rotation = Input.GetAxis("Horizontal") * handlingSpeed * Time.deltaTime;
		var movement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

		transform.Rotate(0, 0, -rotation);
		transform.Translate(0, movement, 0);

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		collitionTimer = TRIGGER_LENGTH;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Boost")
		{
			triggerTimer = TRIGGER_LENGTH;
		}

	}
}
