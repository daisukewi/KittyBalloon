using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour
{
    public void Die(float TimeToDie)
    {
        Collider2D[] Colliders = GetComponents<Collider2D>();

        for (int i = 0; i < Colliders.Length; i++ )
        {
            Colliders[i].isTrigger = true;
        }

        Destroy(gameObject, TimeToDie);
        Debug.Log(name + " Died....");
    }
}
