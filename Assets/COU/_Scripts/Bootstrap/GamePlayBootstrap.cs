using UnityEngine;

namespace COU.Bootstrap
{
    public class GamePlayBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerInitializer _player;
        
        private void Start()
        {
            _player.Initialize();
        }
    }
}