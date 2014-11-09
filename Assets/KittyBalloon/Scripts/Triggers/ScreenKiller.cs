using UnityEngine;
using System.Collections;

public class ScreenKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject Target = other.transform.parent ? other.transform.parent.gameObject : other.gameObject;
        Target.SendMessage("TakeDamage", 2.0f, SendMessageOptions.DontRequireReceiver);
        Debug.Log(Target + " Im dead");
    }
}
