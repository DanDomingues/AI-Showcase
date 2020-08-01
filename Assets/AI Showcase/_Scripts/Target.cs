using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Transform targetMarker;
    [SerializeField] Vector3 positionOffset;
    [SerializeField] string pathPlaneTag;

    int MouseButtonIndex => 0;
    Camera InputCamera => Camera.main;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(MouseButtonIndex))
        {
            Ray ray = InputCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo, 100f, 1, QueryTriggerInteraction.Ignore))
            {
                if(hitInfo.transform.CompareTag(pathPlaneTag))
                {
                    Vector3 targetPosition = hitInfo.point + positionOffset;
                    targetMarker.position = targetPosition;
                }
            }
        }
    }
}
