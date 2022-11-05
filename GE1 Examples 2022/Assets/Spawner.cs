using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject prefab;

    System.Collections.IEnumerator Spawn()
    {
        while(true)
        {
            //Count all prefabs with name "tank"
            int count = GameObject.FindGameObjectsWithTag("tank").Length;
            if(count < 5)
            {
				GameObject g = GameObject.Instantiate<GameObject>(prefab);
				g.AddComponent<Rigidbody>();
				g.transform.position = transform.position;

				g.transform.position += new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
				g.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            }
			yield return new WaitForSeconds(1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
