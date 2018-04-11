using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    public Health HP;
    public void Death()
    {
        HUDManager.OnHPChange.Invoke();
        //remove if time allows
        Debug.Log("quit game");
        Application.Quit();
        //player dead inform gamemanager
    }
    public void OnDamage()
    {
        //player specific 
        HUDManager.Health = HP.CurrentHP;
        HUDManager.OnHPChange.Invoke();
    }
	// Use this for initialization
	void Start () {
        HP.OnDeath = Death;
        HP.OnDamage = OnDamage;
        HUDManager.Health = HP.CurrentHP;
        HUDManager.OnHPChange.Invoke();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
