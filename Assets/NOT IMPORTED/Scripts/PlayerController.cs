using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float ForceAmount;
    public Transform Muzzle;
    public GameObject Bullet;
    public float RPM = 600;
    private float RPMTimer = 0;
	// Use this for initialization
	void Start () {
        //doesnt work for enemies already active in editor only spawned enemies
        GameManager.Player = gameObject;
	}
	void FixedUpdate()
    {
        RPMTimer += Time.deltaTime;
        float axis = Input.GetAxis("Horizontal");
        if (axis != 0)
        {
            rb.AddForce(transform.right * axis * ForceAmount, ForceMode.Force);
        }
        if (Input.GetButton("Fire1"))
        {
            if (RPMTimer >= 0)
            {
                RPMTimer = -1 / (RPM / 60);
                GameObject bull = Instantiate(Bullet, Muzzle.transform.position, Muzzle.transform.rotation, Muzzle);
                bull.GetComponent<Rigidbody>().AddForce(Muzzle.transform.forward * 100, ForceMode.Impulse);
                //fire gun
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
