using UnityEngine;

namespace Effects
{
    public class TransformScaler : TransformEffector
    {
        private Vector3 _startScale;

        private void Awake()
        {
            CheckTargetExist();
            _startScale = Target.localScale;
        }

        public void RestScale() 
        {
            Target.localScale = _startScale;
        }
        public void RandomizeScale() 
        {
            CheckTargetExist();
            Target.localScale = Target.localScale + GetRandomVector();
        }
    } 
}
