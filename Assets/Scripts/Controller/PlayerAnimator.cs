using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private float speedPercent;
    public float locomotionSmoothTime = .1f;
    private CharacterCombat combat;
    private AnimatorOverrideController animatorOverrideController;
    public AnimationClip[] attackAnimationClips;
    public AnimationClip attackPlaceholderAnimClip;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        combat = GetComponent<CharacterCombat>();
        combat.OnAttack += OnAttack;
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }

    void Update()
    {
        speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionSmoothTime, Time.deltaTime);
        animator.SetBool("inCombat", combat.InCombat);
    }

    void OnAttack()
    {
        animator.SetTrigger("attack");
        int attackIndex = Random.Range(0, attackAnimationClips.Length);
        Debug.Log("Attack name: " + attackAnimationClips[attackIndex].name);
        animatorOverrideController[attackPlaceholderAnimClip.name] = attackAnimationClips[attackIndex];
    }
}
