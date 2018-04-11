using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {
    public List<GameObject> Enemies = new List<GameObject>();
    public int MinCount = 1;
    public int MaxCount = 10;
    public float SpawnTime = 10;
    public float Timer;
    public Transform EnemiesHolder;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (HUDManager.TimeSurvived < 30 && HUDManager.TimeSurvived > 10)
        {
            MinCount = 2;
            SpawnTime = 10;
        }
        else if (HUDManager.TimeSurvived > 30 && HUDManager.TimeSurvived < 60)
        {
            MinCount = 6;
            SpawnTime = 5;
        }
        else if (HUDManager.TimeSurvived > 60)
        {
            MinCount = 10;
            MaxCount = 30;
            SpawnTime = 1;
        }
    }
    //keeps track of enemies and spawn timer
    void FixedUpdate()
    {
        Timer += Time.deltaTime;
        if (EnemiesHolder.childCount < MinCount)
        {
            Spawn(FindSpawner());
        }
        else if (EnemiesHolder.childCount < MaxCount)
        {
            if (Timer > SpawnTime)
            {
                Timer = 0;
                Spawn(FindSpawner());
            }
        }
    }
    //finds a spawnpoint that doesnt have an enemy
    public Transform FindSpawner()
    {
        List<Transform> valid = new List<Transform>();
        foreach(Transform child in transform)
        {
            UBSTriggerZone zone = child.GetComponent<UBSTriggerZone>();
            if (zone.GetInteractors(TriggerState.All).Count == 0)
            {
                valid.Add(zone.transform);
            }
        }
        if (valid.Count > 0)
        {
            return valid[Random.Range(0, valid.Count)];
        }
        else
        {
            return null;
        }
    }
    //spawns an enemy 
    public void Spawn(Transform SpawnPoint)
    {
        if (SpawnPoint != null)
        {
            Instantiate(Enemies[Random.Range(0, Enemies.Count)], SpawnPoint.position, new Quaternion(), EnemiesHolder);
        }
    }
}
