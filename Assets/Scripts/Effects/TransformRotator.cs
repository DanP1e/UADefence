using UnityEngine;

namespace Effects
{
    public class TransformRotator : TransformEffector
    {
        public void Rotate(Vector3 angles)
        {
            CheckTargetExist();
            Target.Rotate(angles);
        }
        public void RandomRotate()
        {
            CheckTargetExist();
            Target.Rotate(GetRandomVector());
        }
    }

}