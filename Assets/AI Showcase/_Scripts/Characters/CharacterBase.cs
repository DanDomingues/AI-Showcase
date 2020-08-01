using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;

    public float StoppingDistance => 0.5f;

    protected void MoveTowards(Vector3 target)
    {
        var targetDirection = target - transform.position;
        targetDirection.y = 0f;
        Quaternion targetRot = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        animator.SetFloat("MoveSpeed", 1f);
    }
}
