using UnityEngine;

namespace COU.GamePlay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyCreator : MonoBehaviour
    {
        [SerializeField] private EnemyBrain _prefab;
        [SerializeField] private float _repulsionStrength;
        [SerializeField] private LayerMask _obstacleLayerMask;
        [SerializeField] private Transform _playerTransform;
        
        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            var enemy = Instantiate(_prefab, transform.position, Quaternion.identity);
            var rb = GetComponent<Rigidbody2D>();

            var pathfinder = new PotentialFieldPathfinder(_repulsionStrength, _obstacleLayerMask);
            var mover = new RigidbodyNonGravityMover(rb);
            var rotator = new TransformDirectionRotator(enemy.transform);
            
            enemy.Initialize(pathfinder, _playerTransform, mover, rotator);
        }
    }
}