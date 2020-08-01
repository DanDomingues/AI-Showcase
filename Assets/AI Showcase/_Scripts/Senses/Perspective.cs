namespace AIShowcase.AI.Senses
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Perspective : Sense
    {
        [SerializeField] int fieldOfView = 45;
        [SerializeField] int viewDistance = 100;

        [Header("Runtime")]
        [SerializeField] Transform playerTransform;
        Vector3 rayDirection;

        protected override void Initialize()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        protected override void UpdateSense()
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= detectionRate)
            {
                DetectAspect();
            }
        }

        void DetectAspect()
        {
            rayDirection = playerTransform.position - transform.position;

            if (Vector3.Angle(rayDirection, transform.forward) < fieldOfView)
            {
                if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hitInfo, viewDistance))
                {
                    Aspect aspect = hitInfo.collider.GetComponent<Aspect>();
                    if (aspect != null && aspect.type == aspectType)
                    {
                        Debug.Log("Enemy detected!");
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (playerTransform == null) return;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, playerTransform.position);

            /*
            Gizmos.color = Color.Lerp(Color.green, Color.black, 0.15f);
            Gizmos.DrawWireSphere(transform.position, viewDistance);
            */

            var rightDir = Quaternion.Euler(0, fieldOfView / 2, 0) * Vector3.forward;

            Gizmos.color = Color.Lerp(Color.green, Color.black, 0f);
            Gizmos.DrawLine(transform.position, transform.position + (transform.forward * viewDistance));
            Gizmos.DrawLine(transform.position, transform.position + (rightDir * viewDistance));
            rightDir.x *= -1;
            Gizmos.DrawLine(transform.position, transform.position + (rightDir * viewDistance));
        }
    }
}