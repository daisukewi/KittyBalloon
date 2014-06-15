using UnityEngine;
using System.Collections;

public class NessieSpawner : MonoBehaviour {

    public GameObject Nessie;
    public float NessieCooldownTimer = 5.0f;

    private bool bSpawnNessie = false;
    private bool NessieCooldown = false;
    private Vector2 SpawnPoint;

	// Update is called once per frame
	void Update () {

        if (bSpawnNessie && CanSpawnNessie())
        {
            bSpawnNessie = false;
            Internal_SpawnNessie();
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        SpawnPoint = other.transform.position;
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
        //if(Nessie)
        {
            Debug.Log("SpawnNessie " + SpawnPoint);
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
