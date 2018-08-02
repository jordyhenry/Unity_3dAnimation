using UnityEngine;

public class TelephoneAnswerController : MonoBehaviour 
{

	public float speed = 2.0f;
	public float rotationSpeed = 100.0f;
	Animator m_anim;	
	float weight = 1f;

	public static GameObject controlledBy;
	public Transform phone;
	public Transform receiver;
	public Transform hand;
	public Transform phoneOnHand;

	private void Start() 
	{
		m_anim = GetComponent<Animator>();	
	}

	private void Update() 
	{
		if(controlledBy != null) return;

		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

		transform.Rotate(0 ,rotation, 0);

		if(translation != 0){
			m_anim.SetBool("isWalking", true);
			m_anim.SetFloat("speed", translation);
		}else{
			m_anim.SetBool("isWalking", false);
			m_anim.SetFloat("speed", 0);
		}
	}

	
	private void OnAnimatorIK(int layerIndex) 
	{
		float minWeight = 0.7f;
		weight = m_anim.GetFloat("IKPickUp");
		if(weight > minWeight && m_anim.GetBool("isAnswering")){
			phone.parent = hand;
			phone.localPosition = phoneOnHand.localPosition;
			phone.localRotation = phoneOnHand.localRotation;
		}else if(weight > minWeight && !m_anim.GetBool("isAnswering")){
			phone.parent = receiver;
			phone.localPosition = Vector3.zero;
			phone.localRotation = Quaternion.identity;
		}

		m_anim.SetIKPosition(AvatarIKGoal.RightHand, receiver.position);
		m_anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
	}
}
