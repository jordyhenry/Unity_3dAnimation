using UnityEngine;

public class IkPuppet : MonoBehaviour 
{
	public Transform target;
	Animator m_anim;
	[Range(0,1)]
	public float weight = 1.0f;
	public float speed;

	private void Start() 
	{
		m_anim = GetComponent<Animator>();
	}
	private void Update() 
	{
		float h_mov = Input.GetAxis("Horizontal");
		float v_mov = Input.GetAxis("Vertical");

		target.Translate(new Vector3(-h_mov, v_mov, 0) * speed * Time.deltaTime);
	}

	private void OnAnimatorIK(int layerIndex) {
		m_anim.SetIKPosition(AvatarIKGoal.RightFoot, target.position);
		m_anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, weight);
	}
}
