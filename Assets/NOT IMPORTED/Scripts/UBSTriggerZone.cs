using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum TriggerState
{
    All,
    Enter,
    Stay,
    Exit
}
public class UBSTriggerZone : MonoBehaviour {

    //public 
    [Header("Objects with these tags will be collected when they collide with this object")]
    [Tooltip("leave empty or make an unused tag to not collect any objects")]
    //public List<string> InteractsWithTags;
    public UBSTriggerZoneFilter Filter;
    [System.Serializable]
    public class MyEvent : UnityEvent { }
    [Header("Whenever there is an object that activates the specified state")]
    [Header("Note these events will be run once per frame per state")]
    public MyEvent OnEnter;
    public MyEvent OnStay;
    public MyEvent OnExit;
    //public bool 
    //private
    private List<GameObject> Entered = new List<GameObject>();
    private List<GameObject> Stayed = new List<GameObject>();
    private List<GameObject> Exited = new List<GameObject>();
    //used for other things to access the object that triggered it
    public List<GameObject> GetInteractors(TriggerState triggerState)
    {
        if (triggerState == TriggerState.Enter)
        {
            return Entered;
        }
        else if (triggerState == TriggerState.Stay)
        {
            return Stayed;
        }
        else if (triggerState == TriggerState.Exit)
        {
            return Exited;
        }
        else if (triggerState == TriggerState.All)
        {
            List<GameObject> allInteractors = new List<GameObject>();
            List<System.Collections.Generic.List<GameObject>> listOfLists = new List<System.Collections.Generic.List<GameObject>>();
            listOfLists.Add(Entered);
            listOfLists.Add(Stayed);
            listOfLists.Add(Exited);
            foreach (List<GameObject> list in listOfLists)
            {
                foreach (GameObject interactor in list)
                {
                    if (allInteractors.Contains(interactor) == false)
                    {
                        allInteractors.Add(interactor);
                    }
                }
            }
            return allInteractors;
        }
        else
        {
            Debug.Log("unsupported trigger state");
            return new List<GameObject>();
        }
    }
	// Update is called once per frame
	void Update () {
        if(Entered.Count > 0)
        {
            OnEnter.Invoke();
        }
        if (Stayed.Count > 0)
        {
            OnStay.Invoke();
        }
        if (Exited.Count > 0)
        {
            OnExit.Invoke();
        }
	}
    //clear the lists of objects 
    private void LateUpdate()
    {
        Entered = new List<GameObject>();
        Stayed = new List<GameObject>();
        Exited = new List<GameObject>();
    }
    //add to on enter
    void OnTriggerEnter(Collider other)
    {
        if (Filter.Filter(other.gameObject))
        {
            Entered.Add(other.gameObject);
        }
    }
    //add to inside
    void OnTriggerStay(Collider other)
    {
        //button or currently in
        if (Filter.Filter(other.gameObject))
        {
            Stayed.Add(other.gameObject);
        }
    }
    //add to on exit
    void OnTriggerExit(Collider other)
    {
        //exit
        if (Filter.Filter(other.gameObject))
        {
            Exited.Add(other.gameObject);
        }
    }
}
