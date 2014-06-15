using UnityEngine;
using System.Collections;

public class NessieSpawner : MonoBehaviour {

    public GameObject Nessie;
    public float NessieCooldownTimer = 5.0f;

    private bool bSpawnNessie = false;
    private bool NessieCooldown = false;
    private Vector2 SpawnPoint;
    private GameObject Target;

	// Update is called once per frame
	void Update () {

        if (bSpawnNessie && CanSpawnNessie())
        {
            Internal_SpawnNessie();
        }

        bSpawnNessie = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        SpawnPoint = other.transform.position;
        Target = other.gameObject;
        SpawnNessie();
    }

    bool CanSpawnNessie()
    {
        return !NessieCooldown;
    }

    void SpawnNessie()
    {
        bSpawnNessie = true;
    }

    void Internal_SpawnNessie()
    {
        if(Nessie)
        {
            Vector3 Spawn = new Vector3(SpawnPoint.x, transform.position.y, 0.0f);
            Debug.Log("SpawnNessie " + SpawnPoint);
            GameObject.Instantiate(Nessie, Spawn, transform.rotation);

            Target.SendMessage("TakeDamage", 10.0f, SendMessageOptions.DontRequireReceiver);

            StartNessieCooldown();
        }
    }

    void StartNessieCooldown()
    {
        NessieCooldown = true;
        Invoke("StopNessieCooldown", NessieCooldownTimer);
    }

    void StopNessieCooldown()
    {
        NessieCooldown = false;
    }

}
