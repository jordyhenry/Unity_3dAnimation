using UnityEngine;

public class CubeBlendShape : MonoBehaviour 
{
	SkinnedMeshRenderer m_skinMesh;
	float amount=0;

	private void Start() {
		m_skinMesh = GetComponent<SkinnedMeshRenderer>();	
	}

	private void Update() {
		amount = Input.GetAxis("Vertical") * 100;
		m_skinMesh.SetBlendShapeWeight(0, amount);
	}

}
