using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private GameObject Target;
    public bool Kamikaze = true;
    public float ExplosionRadius = 5;
    public GameObject Explosion;
    public Rigidbody rb;
    public float speed = 15;
	// Use this for initialization
	void Start () {
        Target = GameManager.Player;
        gameObject.transform.LookAt(Target.transform);
	}
    void FixedUpdate()
    {
        float dist = Vector3.Distance(transform.position, Target.transform.position);
        if (!Kamikaze && dist < ExplosionRadius)
        {
            //damage via explode
            Target.GetComponent<IDamageable>().TakeDamage(3);
            Explode();
        }
        else
        {
            transform.LookAt(Target.transform);
            Vector3 desiredVel = transform.forward * speed;
            rb.AddForce((desiredVel - rb.velocity), ForceMode.Force);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Edge")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            //damage via crash
            other.GetComponent<IDamageable>().TakeDamage(1);
            Explode();
        }
    }
    void Explode()
    {
        //spawn explosion
        Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation, null);
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
