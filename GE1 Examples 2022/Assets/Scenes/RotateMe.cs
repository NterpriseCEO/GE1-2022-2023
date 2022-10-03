using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour {
	[Range(0, 360)]
	float speed = 90;
	Renderer dodecahedron;
	float H, S, V;
	// Start is called before the first frame update
	void Start() {
		//get child by name of this prefab
		dodecahedron = GetComponentsInChildren<Renderer>()[0];
	}

	// Update is called once per frame
	void Update() {
		transform.Rotate(Time.deltaTime*speed, Time.deltaTime*speed, -Time.deltaTime*speed);
		Color.RGBToHSV(dodecahedron.material.color, out H, out S, out V);

		dodecahedron.material.color = Color.HSVToRGB(H+=0.001f, S, V);
	}
}
