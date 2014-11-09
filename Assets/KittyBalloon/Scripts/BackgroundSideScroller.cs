using UnityEngine;
using System.Collections;

public class BackgroundSideScroller : MonoBehaviour {

    public float speed = 0.01f;
    public GameObject BG1;
    public GameObject BG2;

    private float TeleportDistance;

	// Use this for initialization
	void Start ()
    {
        if (BG1 && BG2)
        {
            TeleportDistance = BG2.transform.position.x;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (BG1 && BG2)
        {
            MoveLeft(BG1);
            MoveLeft(BG2);

            if (BG1.transform.position.x <= -TeleportDistance)
            {
                Vector3 BG1Position = BG2.transform.position;
                BG1Position.x += TeleportDistance;
                BG1.transform.position = BG1Position;
            }

            if (BG2.transform.position.x <= -TeleportDistance)
            {
                Vector3 BG2Position = BG1.transform.position;
                BG2Position.x += TeleportDistance;
                BG2.transform.position = BG2Position;
            }
        }
	}

    void MoveLeft(GameObject GO)
    {
        Vector3 BG1Position = GO.transform.position;
        BG1Position.x -= speed;
        GO.transform.position = BG1Position;
    }
}
