using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public float stoppingRatio = .8f;

    private bool isFocus = false;
    private Transform player;

    private bool hasInteracted = false;

    public Transform interaction;

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interaction.position);
            if (distance <= radius)
            {
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform newPlayer)
    {
        isFocus = true;
        player = newPlayer;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interaction.position, radius);
    }

}
