using UnityEngine;

public class IKPickup : MonoBehaviour 
{
	Animator m_anim;
	public Transform m_target;
	public Transform m_rightHand;	
	[Range(0,1)]
	public float weight=1f;

	private void Start() {
		m_anim = GetComponent<Animator>();
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Space)){
			m_anim.SetTrigger("pickup");
		}
	}

	private void OnAnimatorIK(int layerIndex) {
		weight = m_anim.GetFloat("IKPickup");
		if(weight > .8f){
			m_target.parent = m_rightHand;
			m_target.localPosition = new Vector3(0.1f, -.14f, .02f);
			m_target.localRotation = Quaternion.Euler(-12.7f,0,-43.3f);
		}

		m_anim.SetIKPosition(AvatarIKGoal.RightHand, m_target.position);
		m_anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
	}
}
