using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventReceiver : MonoBehaviour
{
    private CharacterCombat combat;

    private void Start()
    {
        combat = GetComponent<CharacterCombat>();
    }

    public void AttackHit()
    {
        combat.AttackHitAnimationEvent();
    }
}
