using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("��������")]
    public float maxHealth;
    public float currentHealth;

    [Header("�����޵�")]
    public float invincibleTime;
    private float invincibleCounter;
    public bool invincible;
    public UnityEvent<Character> OnHealthChange;
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDie;

    public void Start()
    {
        currentHealth = maxHealth;
        OnHealthChange?.Invoke(this);
    }

    public void Update()
    {
        if (invincible){
            invincibleCounter -= Time.deltaTime;
            if (invincibleCounter <= 0)
            {
                invincible = false;
            }
        }
    }

    public void TakeDamage(Attack attacker)
    {
        if (invincible)
            return;

        //Debug.Log(attacker.damage);
        if (currentHealth - attacker.damage > 0)
        {
            currentHealth -= attacker.damage;
            Invincible();
            //ִ������
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentHealth = 0;//��������
            OnDie?.Invoke();

        }

        OnHealthChange?.Invoke(this);
    }
    public void Invincible()
    {
        if (!invincible)
        {
            invincible = true;
            invincibleCounter = invincibleTime;
        }
    }
}
