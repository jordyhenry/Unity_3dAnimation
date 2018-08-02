using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveYbot : MonoBehaviour 
{
	public float speed = 5.0f;
	public float rotationSpeed = 100.0f;
	Animator anim;
	float currentSpeed=0;
	float decreaseSpeedFactor = 0.1f;

	private void Start() {
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

		transform.Rotate(0, rotation, 0);
		if(translation != 0)
		{
			anim.SetBool("isWalking", true);
			currentSpeed += translation;
		}else{
			currentSpeed -= decreaseSpeedFactor;
		}

		currentSpeed = Mathf.Clamp(currentSpeed, 0, 5);
		anim.SetFloat("speed",currentSpeed);

		if(currentSpeed == 0)
			anim.SetBool("isWalking", false);
	}
	
}
