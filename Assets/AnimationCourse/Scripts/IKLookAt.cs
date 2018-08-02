using UnityEngine;

public class IKLookAt : MonoBehaviour 
{
	Animator m_anim;
	public Transform m_target;
	[Range(0,1)]
	public float weight = 1f;

	private void Start() {
		m_anim = GetComponent<Animator>();
	}

	private void OnAnimatorIK(int layerIndex) {
		m_anim.SetLookAtPosition(m_target.position);
		m_anim.SetLookAtWeight(weight);
	}
}
