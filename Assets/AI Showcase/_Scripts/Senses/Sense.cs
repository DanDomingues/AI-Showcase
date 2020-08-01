namespace AIShowcase.AI.Senses
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class Sense : MonoBehaviour
    {
        [SerializeField] bool bDebug;
        [SerializeField] protected Aspect.AspectType aspectType;
        [SerializeField] protected float detectionRate;

        protected float elapsedTime;

        protected virtual void Initialize() { }
        protected virtual void UpdateSense() { }

        private void Reset()
        {
            detectionRate = 1.0f;
            aspectType = Aspect.AspectType.Enemy;
        }

        // Start is called before the first frame update
        void Start()
        {
            elapsedTime = 0f;
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateSense();
        }
    }
}