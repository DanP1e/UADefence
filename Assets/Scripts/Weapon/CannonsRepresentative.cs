using System.Linq;
using UnityEngine;
using Utilities;
using Zenject;

namespace Weapon
{
    public class CannonsRepresentative : MonoBehaviour, ICannonsRepresentative
    {
        private IContainer<ICannon> _cannonContainer;

        [Inject]
        public void Construct(IContainer<ICannon> cannonContainer)
        {
            _cannonContainer = cannonContainer;
        }

        public Vector2 GetMinMaxCannonsDamage() 
        {
            bool isFirst = true;
            Vector2 result = Vector2.zero;

            foreach (var cannon in _cannonContainer.GetElements())
            {
                if (isFirst)
                {
                    result = cannon.Damage;
                    isFirst = false;
                }

                result.x = Mathf.Min(result.x, cannon.Damage.x, cannon.Damage.y);
                result.y = Mathf.Max(result.y, cannon.Damage.x, cannon.Damage.y);
            }

            return result;
        }
    }
}
