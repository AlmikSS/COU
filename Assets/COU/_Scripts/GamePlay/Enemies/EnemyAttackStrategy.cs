using UnityEngine;

namespace COU.GamePlay
{
    public abstract class EnemyAttackStrategy : ScriptableObject
    {
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _fleeDistance;
        [SerializeField] private int _damage;

        public float AttackDistance => _attackDistance;
        public float FleeDistance => _fleeDistance;
        public int Damage => _damage;

        public abstract void Attack(Transform origin, Vector2 direction);
    }
}