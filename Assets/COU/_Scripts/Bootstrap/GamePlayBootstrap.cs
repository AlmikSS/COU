using System.Collections.Generic;
using COU.Optimization;
using UnityEngine;

namespace COU.Bootstrap
{
    public class GamePlayBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerInitializer _player;
        [SerializeField] private List<ObjectPool> _objectPools;
        
        private void Start()
        {
            _player.Initialize();

            foreach (var pool in _objectPools)
            {
                pool.Initialize();
            }
        }
    }
}