using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UBSTriggerZoneFilter : MonoBehaviour {
    //logic for filtering
    //true will have the interactor be added to the list
    //false will not have the interactor added to the list
    public virtual bool Filter(GameObject interactor)
    {
        return false;
    }
}
