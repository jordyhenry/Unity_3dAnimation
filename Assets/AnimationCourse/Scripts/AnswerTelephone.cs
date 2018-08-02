using UnityEngine;

public class AnswerTelephone : MonoBehaviour 
{
	public Transform character;
	public Transform anchor;
	bool isWalkingTowards = false;
	bool standingNear = false;
	Animator charAnimator;

	private void Start() 
	{
		charAnimator = character.GetComponent<Animator>();	
	}

	private void Update() 
	{
		if(isWalkingTowards)	
			AutoWalkTowards();
	}

	private void FixedUpdate() 
	{
		AnimLerp();	
	}

	private void OnMouseDown() 
	{
		if(!standingNear){
			charAnimator.SetFloat("speed", 1);
			charAnimator.SetBool("isWalking", true);
			isWalkingTowards = true;
			TelephoneAnswerController.controlledBy = this.gameObject;
		}else{
			charAnimator.SetBool("isAnswering", false);
			isWalkingTowards = false;
			TelephoneAnswerController.controlledBy = null;
			standingNear = false;
		}
	}

	void AutoWalkTowards()
	{
		Vector3 targetDir;
		
		targetDir = new Vector3(
			anchor.position.x - character.position.x,
			0,
			anchor.position.z - character.position.z
		);

		Quaternion rot = Quaternion.LookRotation(targetDir);
		character.transform.rotation = Quaternion.Slerp(character.rotation, rot, 0.05f);

		if(Vector3.Distance(character.position, anchor.position) < 0.1f){
			charAnimator.SetBool("isAnswering", true);
			charAnimator.SetBool("isWalking", false);

			character.rotation = anchor.rotation;

			isWalkingTowards = false;
			standingNear = true;
		}
	}
	
	void AnimLerp()
	{
		if(!standingNear) return;

		if(Vector3.Distance(character.position, anchor.position) > 0.1f){
			character.rotation = Quaternion.Lerp(character.rotation, anchor.rotation, 0.5f * Time.deltaTime);
			character.position = Vector3.Lerp(character.position, anchor.position, 0.5f * Time.deltaTime);
		}else{
			character.position = anchor.position;
			character.rotation = anchor.rotation;
		}
	}
}
