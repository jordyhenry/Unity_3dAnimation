using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour 
{
	public Animator anim;

	private void OnTriggerEnter(Collider other) 
	{
		anim.SetBool("isOpening", true);
	}

	private void OnTriggerExit(Collider other) {
		anim.SetBool("isOpening", false);
	}
}
