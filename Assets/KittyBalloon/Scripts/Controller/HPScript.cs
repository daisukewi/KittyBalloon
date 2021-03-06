﻿using UnityEngine;
using System;
using System.Collections;

public class HPScript : MonoBehaviour {

    [Range(0,2)]
    public float MaxHealthPoints = 2.0f;
    
    public float CurrentHealthPoints = 2.0f;

    public float DamageCooldownDuration = 1.0f;

    private bool TakeDamageCooldown = false;

    public GameObject BalloonsGraphics = null;

    public Action<float> OnHPChanged;

	// Use this for initialization
	void Start ()
    {
        if (BalloonsGraphics)
        {
            Animator BalloonsAnimator = BalloonsGraphics.GetComponent<Animator>();
            if (BalloonsAnimator)
            {
                BalloonsAnimator.SetInteger("Balloons", (int)CurrentHealthPoints);
            }
        }
	}
	
    public bool CanTakeDamage()
    {
        return !TakeDamageCooldown;
    }

    public void TakeDamage(float Damage)
    {
        if(!CanTakeDamage())
        {
            return;
        }

        if (CurrentHealthPoints <= 0)
        {
            Debug.Log("Doing Damage to an already dead character");
            return;
        }

        Debug.Log(name + "Take " + Damage + " Damage");

        CurrentHealthPoints -= Damage;
        CurrentHealthPoints = Mathf.Clamp(CurrentHealthPoints, 0, MaxHealthPoints);
        
        HPChanged();

        if (OnHPChanged != null)
        {
            OnHPChanged(CurrentHealthPoints);
        }

        StartDamageCooldown();
    }

    void StartDamageCooldown()
    {
        TakeDamageCooldown = true;
        Invoke("StopDamageCooldown", DamageCooldownDuration);
    }

    public void StopDamageCooldown()
    {
        TakeDamageCooldown = false;
    }

    public void Heal(float Heal)
    {
        Debug.Log(name + " Heal " + Heal + " Damage");

        CurrentHealthPoints += Heal;
        CurrentHealthPoints = Mathf.Clamp(CurrentHealthPoints, 0, MaxHealthPoints);

        HPChanged();
        OnHPChanged(CurrentHealthPoints);
    }

    public void HPChanged()
    {
        if (CurrentHealthPoints <= 0)
        {
            gameObject.BroadcastMessage("Die", 5.0f, SendMessageOptions.DontRequireReceiver);
        }

        if (BalloonsGraphics)
        {
            Animator BalloonsAnimator = BalloonsGraphics.GetComponent<Animator>();
            if (BalloonsAnimator)
            {
                BalloonsAnimator.SetInteger("Balloons", (int)CurrentHealthPoints);
            }
        }
    }

}
