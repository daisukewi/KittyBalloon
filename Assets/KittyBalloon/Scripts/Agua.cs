using UnityEngine;
using System.Collections;

public class Agua : MonoBehaviour {

    public float DeltaDistance = 1.0f;
    public float VerticalSpeed = 0.1f;
    public float HorizontalSpeed = 0.01f;

    private float RandStart = 1.0f;

    private Vector3 Begin;
    private Vector3 End;

    void Start()
    {
        Begin = transform.parent.Find("Begin").position;
        End = transform.parent.Find("End").position;

        RandStart = Random.Range(0.0f,100.0f);
    }

	// Update is called once per frame
	void FixedUpdate () {

        Vector3 tmp = transform.position;
        tmp.y = Begin.y + (DeltaDistance * Mathf.Sin(VerticalSpeed * (RandStart + Time.frameCount)));
        tmp.x -= HorizontalSpeed;

        if (Mathf.Abs(End.x - tmp.x) <= 0.01)
        {
            tmp = Begin;
        }

        transform.position = tmp;
	}
}
