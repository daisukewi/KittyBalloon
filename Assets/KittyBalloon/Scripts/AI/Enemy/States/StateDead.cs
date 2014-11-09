using UnityEngine;
using System;
using System.Collections;

public class StateDead : StateBaseEnemy
{
    public Action<GameObject> OnDie;

    public void Die(float TimeToDie)
    {
        OnDie(gameObject);

        Debug.Log("StateDead " + name + " Died....");

        if(CanGoToState(StateName))
        {
            GoToState(StateName);
        }

        Transform BalloonsGraphics = transform.Find("BalloonsGraphics");
        if (BalloonsGraphics && BalloonsGraphics.collider2D)
        {
            BalloonsGraphics.collider2D.isTrigger = true;
        }

        if (AnimController)
        {
            AnimController.SetTrigger("OnDie");
        }

        Destroy(gameObject, TimeToDie);
    }
}
