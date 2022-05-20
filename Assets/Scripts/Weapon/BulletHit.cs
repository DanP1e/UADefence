using UnityEngine;

namespace Weapon
{
    public struct BulletHit
    {
        public Vector3 Point;
        public Vector3 Normal;
        public GameObject GameObject;

        public BulletHit(Vector3 point, Vector3 normal, GameObject gameObject)
        {
            Point = point;
            Normal = normal;
            GameObject = gameObject;
        }
    }
}
