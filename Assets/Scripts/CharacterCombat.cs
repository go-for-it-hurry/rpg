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
            StartCoroutine(DoDamage(enemyStats, .6f));
            attackCountdown = 1f / attackRate;
            InCombat = true;
            lastAttackTime = Time.time;
        }
    }
    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
        Debug.Log(transform.name + " attack and " + stats.gameObject.name + " takes " + myStats.damage.GetValue() + " damage");
        if (stats.currentHealth <= 0)
        {
            InCombat = false;
        }
    }
}
