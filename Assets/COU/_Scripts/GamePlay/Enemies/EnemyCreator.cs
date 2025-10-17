using System.Collections;
using UnityEngine;

namespace COU.GamePlay
{
    public class EnemyCreator : MonoBehaviour
    {
        [SerializeField] private EnemyBrain _prefab;
        [SerializeField] private float _repulsionStrength;
        [SerializeField] private LayerMask _obstacleLayerMask;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _minDelay;
        [SerializeField] private float _maxDelay;
        [SerializeField] private int _minEnemyCount;
        [SerializeField] private int _maxEnemyCount;
        [SerializeField] private float _minRadius;
        [SerializeField] private float _maxRadius;

        private void Start()
        {
            StartCoroutine(LiveCycleRoutine());
        }
        
        private IEnumerator LiveCycleRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
                var count = Random.Range(_minEnemyCount, _maxEnemyCount);
                for (var i = 0; i < count; i++)
                {
                    var pos = Random.insideUnitCircle * Random.Range(_minRadius, _maxRadius);
                    Spawn(pos);
                }
            }
        }
        
        private void Spawn(Vector2 position)
        {
            var enemy = Instantiate(_prefab, position, Quaternion.identity);
            var rb = enemy.GetComponent<Rigidbody2D>();

            var pathfinder = new PotentialFieldPathfinder(_repulsionStrength, _obstacleLayerMask);
            var mover = new RigidbodyNonGravityMover(rb);
            var rotator = new TransformDirectionRotator(enemy.transform);
            
            enemy.Initialize(pathfinder, _playerTransform, mover, rotator);
        }
    }
}