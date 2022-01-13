using UnityEngine;

public class Delivery : MonoBehaviour
{
	bool packagePickedUp = false;
	void OnCollisionEnter2D(Collision2D collision)
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		var name = other.gameObject.name;
		Debug.Log("Trigger detected with: " + name + " and " + gameObject.name);

		if (other.tag == "Package" && !packagePickedUp)
		{
			Debug.Log("Package picked up");
			packagePickedUp = true;
		}
		else if (other.tag == "Costumer" && packagePickedUp)
		{
			Debug.Log("Delivered package to customer");
			packagePickedUp = false;
		}
	}
}
