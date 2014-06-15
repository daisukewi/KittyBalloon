using UnityEngine;
using System.Collections;

public class StateBlowing : StateBaseEnemy
{
    public bool CanBlow = true;
    public float BlowCooldown = 10.0f;

    public override void BeginState()
    {
        if(CanBlow)
        {
            StartBlowing();
        }
        else
        {
            Invoke("CheckCanBlow", 0.5f);
        }
    }

    void CheckCanBlow()
    {
        if(enabled)
        {
            if (CanBlow)
            {
                StartBlowing();
            }
            else
            {
                Invoke("CheckCanBlow", 0.5f);
            }
        }
    }

    void FixedUpdate()
    {

    }

    void StartBlowing()
    {
        if (AnimController)
        {
            AnimController.Play("Blowing");
        }

        Invoke("OnBlowFinished", 3.0f);
    }

    void OnBlowFinished()
    {
        
        StartBlowingCooldown();

        if(enabled)
        {
            if (CanGoToState("Flying"))
            {
                SendMessage("Heal", 1.0f);
                GoToState("Flying");
            }
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
