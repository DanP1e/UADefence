using Math;
using System;
using UnityEngine;

namespace Effects
{
    public class TransformEffector : MonoBehaviour

    {
        [SerializeField] protected Transform Target;

        [SerializeField] private RandomVector3 _randomVector;

        public void CheckTargetExist() 
        {
            if (Target == null)
                throw new NullReferenceException($"{nameof(Transform)} in {nameof(Target)} field is null!");
        }
        public Vector3 GetRandomVector() => _randomVector.GetRandomVector();
    }
}
