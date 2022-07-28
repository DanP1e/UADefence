using Effects;
using UnityEngine;
using UnityEngine.Events;
using Weapon.Aim;
using Zenject;

namespace Weapon
{
    public class Tower : MonoBehaviour, ITower
    {
        [SerializeField] private GameObject _towerGameObject;

        private ICannonsRepresentative _cannonsRepresentative;
        private IAimer _aimer;
        private IMagazine _magazine;
        private ITimer _fireTimer;
        private ITimer _reloadTimer;

        public UnityEvent<ITower> Destroying;

        public int MagazineMaxCapacity => _magazine.MaxCapacity;
        public float FireRate => _fireTimer.Interval;
        public float ReloadSpeed => _reloadTimer.Interval;
        public float ShotRange => _aimer.AimRange;
        public Vector2 MinMaxDamage 
            => _cannonsRepresentative.GetMinMaxCannonsDamage();
        public GameObject TowerGameObject => _towerGameObject;

        public event UnityAction<ITower> Destroyed;

        #region Injection

        [Inject]
        public void Construct(
            ICannonsRepresentative cannonsRepresentative,
            IAimer aimer,
            IMagazine magazine,
            [Inject(Id = "fire")] ITimer fire,
            [Inject(Id = "reload")] ITimer reload)
        {
            _cannonsRepresentative = cannonsRepresentative;
            _aimer = aimer;
            _magazine = magazine;
            _fireTimer = fire;
            _reloadTimer = reload;
        }
        #endregion

        public void DestroyTower() 
        {
            Destroy(gameObject);
            Destroying?.Invoke(this);
            Destroyed?.Invoke(this);
        }
    }
}
