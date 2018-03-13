using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour 
{
	Animator anim;

	private void Start() 
	{
		anim = transform.parent.GetComponent<Animator>();	
	}
	private void OnTriggerEnter(Collider other) 
	{
		anim.SetBool("isOpening", true);
	}

	private void OnTriggerExit(Collider other) {
		anim.SetBool("isOpening", false);
	}
}
