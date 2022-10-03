using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
	[SerializeField] GameObject prefab;

	[SerializeField] int loops = 5;
	int maxLoops;
	int n = 0;
	float radius;
	float circumference;
	// Start is called before the first frame update
	void Start() {

		maxLoops = loops;

		while(radius >= 0) {
			loops--;
			radius = loops/2;
			circumference = 2 * Mathf.PI * radius;
			n = (int) (circumference / (2*0.5));
			float s = calculateS();

			while(n > 1 && s < 2*0.5f) {
				n--;
				s = calculateS();
			}

			for (int i = 0; i < n; ++i) {
				float angle = Mathf.PI * 2f * i / n;
				GameObject dd = GameObject.Instantiate(prefab, new Vector3(radius*Mathf.Cos(angle), 0f, radius * Mathf.Sin(angle)), Quaternion.identity);
				dd.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.HSVToRGB(1f/(maxLoops-loops), 1f, 1f);
			}

			radius--;
		}
	}

	float calculateS() {
		return 2*radius*Mathf.Sin(Mathf.PI/n);
	}

	// Update is called once per frame
	void Update() {

	}
}
