using System.Collections.Generic;
using COU.GamePlay;
using COU.Optimization;
using UnityEngine;

namespace COU.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private ObjectPool _projectilePool;
        [SerializeField] private List<Transform> _projectileSpawnPoints;
        
        public void Shoot()
        {
            foreach (var point in _projectileSpawnPoints)
            {
                SpawnProjectile(point.position);
            }
        }

        private void SpawnProjectile(Vector3 position)
        {
            var obj = _projectilePool.Spawn(position, Quaternion.identity);

            if (!obj.TryGetComponent(out Projectile projectile))
                _projectilePool.Despawn(obj);
            
            projectile.Initialize(_projectilePool);
            projectile.Launch(transform.right, gameObject);
        }
    }
}