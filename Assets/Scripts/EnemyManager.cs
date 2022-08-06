using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EnemyManager : Interactable
{
    private CharacterStats myStats;
    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
        myStats.OnHealthReachedZero += Die;
        playerManager = PlayerManager.instance;
    }

    public override void Interact()
    {
        base.Interact();
        playerManager.playerCombat.Attack(myStats);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
