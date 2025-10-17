using System.Collections;
using COU.Interfaces;
using UnityEngine;

namespace COU.GamePlay
{
    public class EnemyBrain : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private EnemyAttackStrategy _attackStrategy;
        
        private IPathfinder _pathfinder;
        private Transform _playerTransform;
        private IMover _mover;
        private IRotator _rotator;
        private EnemyState _state;

        public void Initialize(IPathfinder pathfinder,
            Transform playerTransform, IMover mover, IRotator rotator)
        {
            _pathfinder = pathfinder;
            _playerTransform = playerTransform;
            _mover = mover;
            _rotator = rotator;
            
            _mover.SetSpeed(_speed);
            StartCoroutine(StateMachineRoutine());
        }

        private IEnumerator StateMachineRoutine()
        {
            while (true)
            {
                switch (_state)
                {
                    case EnemyState.Approaching:
                        ApproachingState();
                        break;
                    case EnemyState.Attacking:
                        Attack();
                        break;
                    case EnemyState.Retreating:
                        break;
                }
                
                yield return null;
            }
        }

        private void ApproachingState()
        {
            var direction = _pathfinder.GetDirection(transform.position, _playerTransform.position);
            _mover.Move(direction);
            _rotator.Rotate(direction);

            if (Vector2.Distance(transform.position, _playerTransform.position) < _attackStrategy.AttackDistance)
            {
                _mover.Stop();
                _state = EnemyState.Attacking;
            }
        }

        private void Attack()
        {
            var direction = _pathfinder.GetDirection(transform.position, _playerTransform.position);
            _rotator.Rotate(direction);
            _attackStrategy.Attack(transform.position, transform.forward);

            if (Vector2.Distance(transform.position, _playerTransform.position) > _attackStrategy.AttackDistance)
            {
                _state = EnemyState.Approaching;
            }
        }
    }
    
    public enum EnemyState
    {
        Approaching,
        Attacking,
        Retreating
    }
}