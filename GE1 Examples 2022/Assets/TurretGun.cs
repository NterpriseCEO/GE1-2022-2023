using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : MonoBehaviour
{
    
    public GameObject bulletPrefab;

    public float fireRate = 5;
    Coroutine shootCR = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the gun on the y axis to face the player using quaternions
        transform.rotation = Quaternion.LookRotation(GameObject.Find("tank").transform.position - transform.position);
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.rotation = transform.rotation;
            bullet.transform.forward = bullet.transform.forward;
            bullet.transform.position = new Vector3(transform.position.x-(float)2, transform.position.y + 1, transform.position.z);
            yield return new WaitForSeconds(1/fireRate);
        }
    }

    //OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "tank")
        {
            shootCR = StartCoroutine(ShootCoroutine());
        }
    }

    //OnTriggerExit is called when the Collider other has stopped touching the trigger
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "tank")
        {
            StopCoroutine(shootCR);
            shootCR = null;
        }
    }
}
