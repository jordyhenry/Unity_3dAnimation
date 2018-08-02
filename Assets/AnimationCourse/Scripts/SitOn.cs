using UnityEngine;


public class SitOn : MonoBehaviour 
{
	public Animator char_animator;
	CharController char_controller;
	public Transform anchorPoint;
	bool isSitting = false;
	bool isWalkingTowards=false;

	void Start(){
		char_controller = char_animator.GetComponent<CharController>();
	}

	private void Update() {
		if(isWalkingTowards)
			AutoWalkTowards();
	}
	
	void FixedUpdate() {
		AnimLerp();
	}
	private void OnMouseDown() {
		if(char_animator == null)
			return;

		if(!isSitting){
			char_animator.SetFloat("speed",1 );
			char_animator.SetBool("isWalking", true);
			isWalkingTowards = true;
			char_controller.isWalkingTowardsChair = true;
		}else{
			char_animator.SetBool("isSitting", false);
			isWalkingTowards = false;
			isSitting = false;
			char_controller.isWalkingTowardsChair = false;
		}
	}

	void AutoWalkTowards()
	{
		Vector3 targetDir;
		targetDir = new Vector3(
			anchorPoint.position.x - char_controller.transform.position.x,
			0f,
			anchorPoint.position.z - char_controller.transform.position.z
		);

		Quaternion rot = Quaternion.LookRotation(targetDir);
		char_controller.transform.rotation = Quaternion.Slerp(char_controller.transform.rotation, rot, 0.5f);

		if(Vector3.Distance(char_controller.transform.position, anchorPoint.position) < 0.9f){
			char_animator.SetBool("isSitting", true);
			char_animator.SetBool("isWalking",false);

			char_controller.transform.rotation = anchorPoint.rotation;

			isWalkingTowards = false;
			isSitting = true;
		}
	}

	void AnimLerp()
	{
		if(!isSitting) return;

		if(Vector3.Distance(char_controller.transform.position, anchorPoint.position) > 0.1f){
			char_controller.transform.rotation = Quaternion.Slerp(
				char_controller.transform.rotation,
				anchorPoint.rotation,
				0.5f * Time.deltaTime
			);

			char_controller.transform.position = Vector3.Lerp(
				char_controller.transform.position,
				anchorPoint.position,
				0.5f * Time.deltaTime
			);
		}else{
			char_controller.transform.rotation = anchorPoint.rotation;
			char_controller.transform.position = anchorPoint.position;
		}
	}
}
