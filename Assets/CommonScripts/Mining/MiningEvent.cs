using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningEvent : EventComponent
{

    public override void TriggerEvent()
    {
        print("mine");
        Vector3 val = new Vector3(0.2f,0.2f,0.2f);
        transform.localScale -= val;
    }
    
    protected override void Update()
    {
        
    }
}
