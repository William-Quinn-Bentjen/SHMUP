using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UBSTriggerZoneTagFilter : UBSTriggerZoneFilter {
    //tags to check 
    public List<string> InteractsWithTags = new List<string>();
    //filter logic
    public override bool Filter(GameObject interactor)
    {
        //check if the interactor's tag is in the list of tags to check
        if (InteractsWithTags.Contains(interactor.tag))
        {
            return true;
        }
        return false;
    }
}
