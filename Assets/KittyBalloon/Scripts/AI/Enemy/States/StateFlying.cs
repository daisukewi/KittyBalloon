using UnityEngine;
using System.Collections;

public class StateFlying : StateBase
{
    public float MinVelocity = 20.0f;
    public float MaxVelocity = 25.0f;

    public Vector2 Direction;

    override protected void InitState()
    {
        base.InitState();
        InvokeRepeating("ChangeDirection", 0.1f, 2.0f);

    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        if(enabled)
        {
            // Add a vertical force to the player.
            rigidbody2D.AddForce(Direction);
        }
	}

    void ChangeDirection()
    {
        Direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(1.0f, 1.0f));

        Direction *= Random.Range(MinVelocity, MaxVelocity);
    }
}
