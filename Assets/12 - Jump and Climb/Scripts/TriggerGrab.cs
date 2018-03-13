using UnityEngine;

public class TriggerGrab : MonoBehaviour 
{
	public Transform rootPos;

	private void OnTriggerEnter(Collider other) {
		other.GetComponentInParent<ClimbUp>().GrabEdge(rootPos);
	}

}
