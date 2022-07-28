using System;
using UnityEngine;

namespace Effects
{
    public class ExplosionRepresentative : MonoBehaviour
    {
        [SerializeField] private GameObject _rootExplosionObject;

        public GameObject RootObject { get => _rootExplosionObject; }

        public void ExplodeIn(Vector3 explosionPoint, float explosionScale) 
        {
            
        }
    }
}
