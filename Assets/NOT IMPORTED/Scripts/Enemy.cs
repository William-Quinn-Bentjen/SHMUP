using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Health HP;
    public int score = 1;
    public void Death()
    {
        //used to tell the HUD manager how many points killing this enemy is worth
        HUDManager.Kills++;
        HUDManager.OnKill.Invoke();
        HUDManager.Score += score * HUDManager.TimeSurvived;
        HUDManager.OnScore.Invoke();
        Destroy(gameObject);
    }
	// Use this for initialization
	void Start () {
        HP.OnDeath = Death;
        HP.OnDamage = Damaged;
	}
    public void Damaged()
    {

    }
    
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
