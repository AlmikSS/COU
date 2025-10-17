using UnityEngine;

namespace COU.GamePlay
{
    [CreateAssetMenu(menuName = "Enemy/ShootAttackStrategy")]
    public class EnemyShootAttackStrategy : EnemyAttackStrategy
    {
        [SerializeField] private Vector2 _offset;
        [SerializeField] private Projectile _projectilePrefab;
        
        public override void Attack(Vector2 origin, Vector2 direction)
        {
            var projectile = Instantiate(_projectilePrefab, origin + _offset, _projectilePrefab.transform.rotation);
            projectile.Launch(direction);
        }
    }
}