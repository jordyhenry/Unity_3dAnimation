using UnityEngine;
using System.Collections;

public class FlyBall : MonoBehaviour {

	float t = 0;
	public float radius = 1;
	
	// Update is called once per frame
	void Update () {

		float newX = Mathf.Cos(t) * radius;
		float newZ = Mathf.Sin(t);

		this.transform.position = new Vector3(newX, this.transform.position.y, newZ);
		t += 0.01f;
	}
}
