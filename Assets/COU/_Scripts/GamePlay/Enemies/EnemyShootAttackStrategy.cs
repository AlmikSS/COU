using UnityEngine;

namespace COU.GamePlay
{
    [CreateAssetMenu(menuName = "Enemy/ShootAttackStrategy")]
    public class EnemyShootAttackStrategy : EnemyAttackStrategy
    {
        [SerializeField] private Vector2 _offset;
        [SerializeField] private Projectile _projectilePrefab;
        
        public override void Attack(Transform origin, Vector2 direction)
        {
            var pos = origin.position + origin.TransformDirection(_offset);
            var projectile = Instantiate(_projectilePrefab, pos, _projectilePrefab.transform.rotation);
            projectile.SetDamage(Damage);
            projectile.Launch(direction, origin.gameObject);
        }
    }
}