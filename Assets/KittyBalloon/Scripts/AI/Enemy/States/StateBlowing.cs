using UnityEngine;
using System.Collections;

public class StateBlowing : StateBase
{
    public bool CanBlow = true;
    public float BlowCooldown = 10.0f;

    public override void BeginState()
    {
        if(CanBlow)
        {
            StartBlowing();
        }
    }

    public override void EndState()
    {
        //Debug.Log ("StateBase EndState");
    }

    void FixedUpdate()
    {

    }

    void StartBlowing()
    {
        Invoke("OnBlowFinished", 3.0f);
    }

    void OnBlowFinished()
    {
        StartBlowingCooldown();
        if(CanGoToState("Flying"))
        {
            GoToState("Flying");
        }
    }

    void StartBlowingCooldown()
    {
        CanBlow = false;
        Invoke("StopBlowingCooldown", BlowCooldown);
    }

    void StopBlowingCooldown()
    {
        CanBlow = true;
    }
}
