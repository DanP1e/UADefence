using UnityEngine;

namespace Weapon.Aim
{
    public class SphericalAreaPresenter : MonoBehaviour, IAreaPresenter
    {
        [SerializeField] private float _range = 12f;

        public float AreaScale 
        { 
            get => _range; 
            set => _range = value; 
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _range);
        }       

        public bool IsInArea(Vector3 targetPosition)
        {
            return Vector3.Distance(transform.position, targetPosition) <= _range;
        }
    }
}
