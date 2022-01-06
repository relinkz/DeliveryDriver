using UnityEngine;

public class Driver : MonoBehaviour
{
	[SerializeField] float handlingSpeed = 100.0f;
	[SerializeField] float baseSpeed = 4.0f;

	void Update()
	{
		HandleMovement();
	}

	void HandleMovement()
	{
		var rotation = Input.GetAxis("Horizontal") * handlingSpeed * Time.deltaTime;
		var movement = Input.GetAxis("Vertical") * baseSpeed * Time.deltaTime;

		transform.Rotate(0, 0, -rotation);
		transform.Translate(0, movement, 0);
	}
}
