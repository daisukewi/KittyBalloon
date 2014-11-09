using UnityEngine;
using System.Collections;

public class StateFalling : StateBaseEnemy
{

    private Transform groundCheck;			// A position marking where to check if the player is grounded.

	// Use this for initialization
    override protected void InitState()
    {
        base.InitState();
        groundCheck = transform.Find("groundCheck");
    }

    public override void BeginState()
    {
        if (AnimController)
        {
            AnimController.SetTrigger("OnFall");
        }
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        bool grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(grounded)
        {
            if(CanGoToState("Blowing"))
            {
                GoToState("Blowing");
            }
        }
	}
}
