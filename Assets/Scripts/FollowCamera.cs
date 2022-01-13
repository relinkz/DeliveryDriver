using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	[SerializeField] GameObject followObject;

	void LateUpdate()
	{
		var objectPos = followObject.transform.position;
		transform.position = new Vector3(objectPos.x, objectPos.y, transform.position.z);
	}
}
