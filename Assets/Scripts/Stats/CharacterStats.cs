using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; protected set; }
    public Stat damage;
    public Stat armor;
    public virtual void Awake()
    {
        currentHealth = maxHealth;
    }
    public virtual void Start()
    {

    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {

        }
    }
}
