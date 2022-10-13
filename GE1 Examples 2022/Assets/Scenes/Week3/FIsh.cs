using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIsh : MonoBehaviour {
	
	GameObject head, tail, headParent, tailParent;
	[Range(0.0f, 5.0f)]
	[SerializeField] float frequency = 0.5f;
	[SerializeField] int headAmplitude = 40;
	[SerializeField] int tailAmplitude = 20;
	[SerializeField] float theta;
	
	// Start is called before the first frame update
	void Start() {
		//create empty game object for headParent
		headParent = new GameObject();
		headParent.transform.parent = transform;

		head = GameObject.CreatePrimitive(PrimitiveType.Cube);
		head.name = "Head";
		head.transform.localScale = new Vector3(5f, 1f, 1f);
		head.transform.position = new Vector3(-2.5f, 0f, 0f);
		head.transform.parent = headParent.transform;
		headParent.transform.position = new Vector3(-2.5f, 0f, 0f);

		//create empty game object for tailParent
		tailParent = new GameObject();
		tailParent.transform.parent = transform;

		tail = GameObject.CreatePrimitive(PrimitiveType.Cube);
		tail.name = "Tail";
		tail.transform.localScale = new Vector3(5f, 1f, 1f);
		tail.transform.position = new Vector3(2.5f, 0f, 0f);
		tail.transform.parent = tailParent.transform;
		tailParent.transform.position = new Vector3(2.5f, 0f, 0f);
	}

	// Update is called once per frame
	void Update() {
		float headAngle = Mathf.Sin(theta) * headAmplitude;
		float tailAngle = Mathf.Sin(theta) * tailAmplitude;

		headParent.transform.localRotation = Quaternion.AngleAxis(headAngle, Vector3.forward);
		tailParent.transform.localRotation = Quaternion.AngleAxis(tailAngle, Vector3.forward);

		theta += frequency * 2.0f * Mathf.PI * Time.deltaTime;
	}
}