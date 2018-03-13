using UnityEngine;

public class BorisBlendController : MonoBehaviour 
{
	SkinnedMeshRenderer m_skinMesh;
	float blink = 0;
	float open = 0;
	float mouseY = 0;

	private void Start() {
		m_skinMesh = GetComponent<SkinnedMeshRenderer>();	
	}

	private void Update() {
		blink = Input.GetAxis("Vertical") * 100;
		open = Input.GetAxis("Horizontal") * 100;
		mouseY = -Input.mousePosition.y;

		m_skinMesh.SetBlendShapeWeight(0, blink);
		m_skinMesh.SetBlendShapeWeight(1, open);
		m_skinMesh.SetBlendShapeWeight(2, mouseY);
	}

}
