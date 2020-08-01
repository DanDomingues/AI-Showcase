using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterBase
{
    [Header("Runtime")]
    public Transform targetTransform;

    private void Update()
    {
        if (targetTransform == null) return;

        //0.5f acts as the stopping distance
        if(Vector3.Distance(transform.position, targetTransform.position) < StoppingDistance)
        {
            animator.SetFloat("MoveSpeed", 0f);
            return;
        }

        MoveTowards(targetTransform.position);
    }
}
