using UnityEngine;

public class BorisBlendController : MonoBehaviour 
{
	SkinnedMeshRenderer m_skinMesh;
	float blink = 0;
	float open = 0;
	float mouth = 0;

	private void Start() {
		m_skinMesh = GetComponent<SkinnedMeshRenderer>();	
	}

	private void Update() {
		blink = Input.GetAxis("Vertical") * 100;
		open = Input.GetAxis("Horizontal") * 100;
		
		if(Input.GetKey(KeyCode.Space))
			mouth += 2f;
		else
			mouth -= 2f;
		
		mouth =Mathf.Clamp(mouth, 0f, 100f);

		m_skinMesh.SetBlendShapeWeight(0, blink);
		m_skinMesh.SetBlendShapeWeight(1, open);
		m_skinMesh.SetBlendShapeWeight(2, mouth);
	}

}
