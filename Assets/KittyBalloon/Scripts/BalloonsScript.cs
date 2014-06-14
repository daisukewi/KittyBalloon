using UnityEngine;
using System.Collections;

public class BalloonsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject && gameObject.transform.parent)
        {
            gameObject.transform.parent.SendMessage("TakeDamage", 1.0f);
        }
    }
}
