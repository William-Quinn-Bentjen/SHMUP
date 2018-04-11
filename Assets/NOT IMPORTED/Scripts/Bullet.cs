using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage = 1;
    public float LifeDuration = 5;
    public float timer = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<IDamageable>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > LifeDuration)
        {
            Destroy(gameObject);
        }
    }
}
