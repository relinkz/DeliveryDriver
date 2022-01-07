using UnityEngine;

public class Collition : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		var name = collision.gameObject.name;
		Debug.Log("collition detected with: " + name + " and " + gameObject.name);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
			var name = other.gameObject.name;
		Debug.Log("Trigger detected with: " + name + " and " + gameObject.name);	
	}
}
