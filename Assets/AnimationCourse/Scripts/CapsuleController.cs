using UnityEngine;

public class CapsuleController : MonoBehaviour 
{
	public float speed  =5;
	private void Update() 
	{
		float mov = Input.GetAxis("Horizontal")	* Time.deltaTime * speed;
		transform.Translate(Vector3.forward * mov);
	}		
}
