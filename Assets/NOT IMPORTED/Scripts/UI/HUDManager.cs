using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    //NOTE I WAS GOING TO MAKE THE HUD AS DISCONNECTED AS POSSIBLE BUT DIDN'T HAVE TIME IF I WANTED IT TO WORK
    public static int Score = 0;
    public delegate void ChangeScore();
    public static ChangeScore OnScore;
    public Text ScoreTxt;
    public static int Health = 0;
    public delegate void ChangeHP();
    public static ChangeHP OnHPChange;
    public Text HP;
    public static int TimeSurvived = 0;
    public delegate void ChangeTimeCount();
    public static ChangeTimeCount OnTime;
    public Text Timer;
    public static int Kills = 0;
    public delegate void ChangeKillCount();
    public static ChangeKillCount OnKill;
    public Text KillCount;

    private float timer = 0;
	// Use this for initialization
	void Start () {
        OnKill = UpdateKillCount;
        OnHPChange = UpdateHP;
        OnScore = UpdateScoreCount;
        OnTime = UpdateTimeCount;
        OnKill.Invoke();
        OnTime.Invoke();
        OnScore.Invoke();
	}
    void UpdateKillCount()
    {
        KillCount.text = Kills + " Kills"; 
    }
    void UpdateScoreCount()
    {
        ScoreTxt.text = Score + " Points";
    }
    void UpdateTimeCount()
    {
        Timer.text = TimeSurvived + " Seconds";
    }
    void UpdateHP()
    {
        HP.text = Health + " HP";
    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        int newT = Mathf.FloorToInt(timer);
        if (newT > TimeSurvived)
        {
            TimeSurvived = newT;
            OnTime.Invoke();
            //invoke 
        }
	}
}
