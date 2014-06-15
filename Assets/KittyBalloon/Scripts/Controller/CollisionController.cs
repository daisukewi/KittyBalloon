using UnityEngine;
using System.Collections;

public class CollisionController: MonoBehaviour {

    public float Bounciness = 1.5f;
    public float GroundNormal = 0.9f;

    public Animator AnimController;
    Transform GetParent()
    {
        return gameObject.transform.parent;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Balloons")
        {
            if (coll.gameObject.GetTeam() == gameObject.GetTeam())
            {
                
            }
            else
            {
                if (AnimController)
                {
                    AnimController.Play("HitSomeone");
                }

                coll.collider.transform.parent.SendMessage("TakeDamage", 1.0f);
            }
        }

        Vector2 collNormal = ((ContactPoint2D)coll.contacts.GetValue(0)).normal;

        if (collNormal.y < GroundNormal)
        {
            Vector2 reflection = coll.relativeVelocity - 2 * Vector2.Dot(coll.relativeVelocity, collNormal) * collNormal;
            rigidbody2D.velocity = reflection / Bounciness;
        }
    }
}
