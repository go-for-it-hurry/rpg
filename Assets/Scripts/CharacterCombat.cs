using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    private CharacterStats myStats;
    private float attackCountdown = 0f;
    public float attackRate = 1f;
    public event System.Action OnAttack = null;
    public bool InCombat { get; private set; }
    public float combatCoolingTime = 5f;
    private float lastAttackTime = .0f;
    private CharacterStats enemyStats;
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCountdown -= Time.deltaTime;
        if (Time.time - lastAttackTime > combatCoolingTime)
        {
            InCombat = false;
        }
    }

    public void Attack(CharacterStats enemyStats)
    {
        if (attackCountdown <= 0f)
        {
            if (OnAttack != null)
            {
                OnAttack();
            }
            this.enemyStats = enemyStats;
            attackCountdown = 1f / attackRate;
            InCombat = true;
            lastAttackTime = Time.time;
        }
    }
    public void AttackHitAnimationEvent()
    {
        this.enemyStats.TakeDamage(myStats.damage.GetValue());
        Debug.Log(transform.name + " attack and " + this.enemyStats.gameObject.name + " takes " + myStats.damage.GetValue() + " damage");
        if (this.enemyStats.currentHealth <= 0)
        {
            InCombat = false;
        }
    }
}
