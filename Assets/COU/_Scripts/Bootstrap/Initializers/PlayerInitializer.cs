using COU.GamePlay;
using COU.Player;
using UnityEngine;

namespace COU.Bootstrap
{
    public class PlayerInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private PlayerScanner _playerScanner;
        [SerializeField] private ScannerUI _scannerUI;
        [SerializeField] private PlayerCombat _playerCombat;
        [SerializeField] private Joystick _joystick;

        public void Initialize()
        {
            var rb = GetComponent<Rigidbody2D>();
            
            var mover = new RigidbodyNonGravityMover(rb);
            var rotator = new TransformDirectionRotator(transform);
            
            _playerController.Initialize(mover, rotator,
                _joystick, _playerScanner, _playerCombat);
            _playerScanner.OnScanEvent += _scannerUI.ShowInfo;
        }
    }
}