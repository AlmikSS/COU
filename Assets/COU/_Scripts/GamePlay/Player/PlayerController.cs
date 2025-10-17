using COU.Interfaces;
using UnityEngine;

namespace COU.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        
        private IMover _mover;
        private IRotator _rotator;
        private Joystick _joystick;
        private PlayerScanner _playerScanner;
        private PlayerCombat _playerCombat;
        private Vector2 _moveDirection;

        public void Initialize(IMover mover,
            IRotator rotator,
            Joystick joystick,
            PlayerScanner playerScanner,
            PlayerCombat playerCombat)
        {
            _mover = mover;
            _rotator = rotator;
            _joystick = joystick;
            _playerScanner = playerScanner;
            _playerCombat = playerCombat;
            
            _mover.SetSpeed(_maxSpeed);
        }

        private void Update()
        {
            if (_joystick != null)
                _moveDirection = _joystick.Direction.normalized;
            
            #if UNITY_EDITOR
            if (_moveDirection.magnitude < 0.1f)
                _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            #endif
            
            _rotator.Rotate(_moveDirection);
            
            if (Input.GetKeyDown(KeyCode.Space))
                _playerScanner.Scan();
            
            if (Input.GetKeyDown(KeyCode.R))
                _playerCombat.Shoot();
        }
        
        private void FixedUpdate()
        {
            _mover?.Move(_moveDirection);
        }
    }
}