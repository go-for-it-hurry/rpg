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
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCountdown -= Time.deltaTime;
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
        }
    }
    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
        Debug.Log(transform.name + " attack and " + stats.gameObject.name + " takes " + myStats.damage.GetValue() + " damage");
    }
}
