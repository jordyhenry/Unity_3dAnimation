using System.Collections;
using UnityEngine;

public class SimpleDriveCharacter : MonoBehaviour 
{
	public float speed = 5.0f;
	public float rotationSpeed = 100.0f;

	Animator anim;

	private void Start() 
	{
		anim = GetComponent<Animator>();
	}

	private void Update() 
	{
		float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);

		if(translation != 0){
			anim.SetBool("isWalking", true);
			anim.SetFloat("speed", translation * 10);
		}else{
			anim.SetBool("isWalking", false);
			anim.SetFloat("speed", 0);
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			anim.SetTrigger("isJumping");
		}
	}
	
}
