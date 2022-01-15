using UnityEngine;

public class Delivery : MonoBehaviour
{
	bool packagePickedUp = false;
	[SerializeField] float delayBeforeDestoryOnPickup;
	[SerializeField] Color32 pickupColor = new Color32(0,1,0,1);
	[SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
	SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
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
			Destroy(other.gameObject, delayBeforeDestoryOnPickup);

			spriteRenderer.color = pickupColor;
		}
		else if (other.tag == "Costumer" && packagePickedUp)
		{
			Debug.Log("Delivered package to customer");
			packagePickedUp = false;

			spriteRenderer.color = noPackageColor;
		}
	}
}
