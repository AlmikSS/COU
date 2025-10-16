using COU.Interfaces;
using COU.Optimization;
using UnityEngine;

namespace COU.GamePlay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private int _damage;

        private Rigidbody2D _rb;
        private ObjectPool _projectilePool;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        public void Initialize(ObjectPool pool)
        {
            _projectilePool = pool;
        }
        
        public void Launch(Vector2 direction)
        {
            _rb.linearVelocity = direction * _speed;
            Invoke(nameof(ReturnToPool), _lifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damage);
            
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            if (_projectilePool != null)
                _projectilePool.Despawn(gameObject);
        }
    }
}