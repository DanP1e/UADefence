using System;
using UnityEngine;

namespace Math
{
    [Serializable]
    public class RandomVector3
    {
        [SerializeField] private Vector2 _axisXMinMax;
        [SerializeField] private Vector2 _axisYMinMax;
        [SerializeField] private Vector2 _axisZMinMax;

        public RandomVector3(Vector2 axisXMinMax, Vector2 axisYMinMax, Vector2 axisZMinMax)
        {
            _axisXMinMax = axisXMinMax;
            _axisYMinMax = axisYMinMax;
            _axisZMinMax = axisZMinMax;
        }

        public Vector3 GetRandomVector() 
            => new Vector3(UnityEngine.Random.Range(_axisXMinMax.x, _axisXMinMax.y),
                           UnityEngine.Random.Range(_axisYMinMax.x, _axisYMinMax.y),
                           UnityEngine.Random.Range(_axisZMinMax.x, _axisZMinMax.y));
    }
}
