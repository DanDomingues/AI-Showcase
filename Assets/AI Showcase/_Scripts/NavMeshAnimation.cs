using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class NavMeshAnimation : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] float maxSpeed;

    private void Reset()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        if (agent) maxSpeed = agent.speed;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("MoveSpeed", agent.velocity.magnitude / maxSpeed);
    }
}
