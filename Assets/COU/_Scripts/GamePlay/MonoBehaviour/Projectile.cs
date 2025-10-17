using COU.Interfaces;
using COU.Optimization;
using UnityEngine;

namespace COU.GamePlay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Transform _vfxSpawnpoint;
        [SerializeField] private GameObject _vfxPrefab;
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private int _damage;

        private GameObject _currentVfx;
        private Rigidbody2D _rb;
        private ObjectPool _projectilePool;
        private GameObject _sender;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        public void Initialize(ObjectPool pool)
        {
            _projectilePool = pool;
        }

        public void SetDamage(int damage)
        {
            _damage = damage;
        }
        
        public void Launch(Vector2 direction, GameObject sender)
        {
            _rb.linearVelocity = direction * _speed;
            _sender = sender;
            
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            _currentVfx = Instantiate(_vfxPrefab, _vfxSpawnpoint.position, _vfxPrefab.transform.rotation, _vfxSpawnpoint);
            Destroy(_currentVfx, 3);
            Invoke(nameof(ReturnToPool), _lifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == _sender)
                return;
            
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            { 
                damageable.TakeDamage(_damage);
            }
            
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            if (_currentVfx != null)
                _currentVfx.transform.SetParent(null);
            
            if (_projectilePool != null)
                _projectilePool.Despawn(gameObject);
            else
                Destroy(gameObject);
        }
    }
}