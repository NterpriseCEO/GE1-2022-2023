using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{

    //boolean destroyed
    bool destroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    System.Collections.IEnumerator destroyTank()
    {
        yield return new WaitForSeconds(4);
        //disable rigidbody and collider on tank
        Rigidbody rb = GetComponent<Rigidbody>();
        // rb.isKinematic = true;
        rb.detectCollisions = false;
        rb.drag = 1;
        //disable rigidbody and collider on turret
        Rigidbody rb2 = transform.GetChild(0).GetComponent<Rigidbody>();
        // rb2.isKinematic = true;
        rb2.detectCollisions = false;
        rb2.drag = 1f;

        yield return new WaitForSeconds(3);
        Destroy(gameObject.transform.parent.gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tank hit by " + collision.gameObject.tag);
        if (collision.gameObject.tag == "bullet" && !destroyed)
        {
            destroyed = true;
            Destroy(collision.gameObject);
            //get first child of transform
            Transform t = transform.GetChild(0);
            t.gameObject.AddComponent<Rigidbody>();
            //set gravity
            t.gameObject.GetComponent<Rigidbody>().useGravity = true;
            //set random velocity
            t.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));

            t = transform.GetChild(1);
            t.gameObject.AddComponent<Rigidbody>();
            //set gravity
            t.gameObject.GetComponent<Rigidbody>().useGravity = true;

            StartCoroutine(destroyTank());
        }
    }
}
