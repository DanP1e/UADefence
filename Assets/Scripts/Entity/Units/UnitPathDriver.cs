using InspectorAddons;
using PathSystem;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Entity.Units
{
    public class UnitPathDriver : UnitDriver, IPathDriver
    {
        [SerializeField] private float _tragetReachDistance = 0.5f;
        [SerializeField] private InterfaceComponent<IPathPresenter> _pathPresenterComponent;

        private bool _isUpdating = false;
        private IEnumerator _currentRutine;
        private IPathPresenter _pathPresenter;
        private Vector3 _pathPoint;

        public UnityEvent TargetReached;
        
        public event Action<IPathDriver, IPathPresenter> LeftPath;

        private IEnumerator StartMovementProcess(Vector3 target)
        {
            while (true)
            {
                if (Vector3.Distance(Unit.GetInteractPoint(), target) < _tragetReachDistance)
                {
                    TargetReached?.Invoke();
                    UpdateTarget();
                    break;
                }
                Unit.MakeMovementFrame(target, Speed);
                yield return new WaitForEndOfFrame();
            }
        }
        private void UpdateTarget()
        {
            if (!_isUpdating)
            {
                Vector3 unitPosition = Unit.GetInteractPoint();
                _pathPoint = _pathPresenter.GetPathPoint(unitPosition);
            }
            else
            {
                _pathPoint = _pathPresenter.GetPathPoint(_pathPoint);
            }

            _isUpdating = true;
            MoveTo(_pathPoint);
            _isUpdating = false;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_pathPoint, _tragetReachDistance);
        }

        protected override void Awake()
        {
            base.Awake();
            if (_pathPresenterComponent.IsNull())
                return;

            _pathPresenter = _pathPresenterComponent.Interface;
            UpdateTarget();
        }
        protected virtual void OnDestroy()
        {
            LeftPath?.Invoke(this, _pathPresenter);
        }

        public override void MoveTo(Vector3 target)
        {
            Stop();
            _currentRutine = StartMovementProcess(target);
            StartCoroutine(_currentRutine);
        }
        public override void Stop()
        {
            if (_currentRutine != null)
                StopCoroutine(_currentRutine);
        }
        public void SetPathPresenter(IPathPresenter pathPresenter)
        {
            if (pathPresenter == null)
                throw new ArgumentNullException();

            LeftPath?.Invoke(this, _pathPresenter);
            _pathPresenter = pathPresenter;
            UpdateTarget();
        }
        public float GetPathProgress()
        {
            if (_pathPresenter == null)
                throw new NullReferenceException($"{nameof(_pathPresenter)} is null!");

            return _pathPresenter.GetProgress(Unit.GetInteractPoint());
        }
    }
}
