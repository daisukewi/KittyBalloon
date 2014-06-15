﻿using UnityEngine;
using System.Collections;

public class ScrollScreenController : MonoBehaviour {

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

    void OnBecameInvisible()
    {
        Vector2 position = GetParent().transform.position;

        position.x = -position.x + (position.x > 0 ? 0.1f : -0.1f);
        GetParent().transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.collider.tag);
        if (other.collider.tag == "DieHard")
        {
            transform.parent.BroadcastMessage("TakeDamage", 2.0f);
            Debug.Log("Im dead");
        }
    }
}
