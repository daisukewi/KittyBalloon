using UnityEngine;
using System.Collections;

public class StateDead : StateBaseEnemy
{
	// Update is called once per frame
	void Update () {
	
	}

    public void Die(float TimeToDie)
    {
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

        Destroy(gameObject, TimeToDie);
    }
}
