using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerDelay : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Animation;
    private float Delay=2f;
    private float TickTime;
    // Update is called once per frame
    void Update()
    {
        if (Animation.GetBool("IsOpen"))
        {
            TickTime+=Time.deltaTime;
            if(TickTime>Delay)
            {
                Animation.SetBool("IsOpen",false);
                TickTime=0f;
            }
        }
    }
}
