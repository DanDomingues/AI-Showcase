using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : CharacterBase
{
    [SerializeField] float minX, maxX, minZ, maxZ;

    Vector3 startPosition;
    Vector3 targetPos;

    private void Reset()
    {
        minX = -45f;
        maxX = 45f;

        minZ = -45f;
        maxZ = 45f;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        GetNextPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, targetPos) < StoppingDistance)
        {
            GetNextPosition();
        }

        MoveTowards(targetPos);
    }

    void GetNextPosition()
    {
        targetPos = startPosition + new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
    }
}
