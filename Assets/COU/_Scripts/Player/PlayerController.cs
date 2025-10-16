using COU.Interfaces;
using UnityEngine;

namespace COU.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        
        private IMoveable _mover;
        private IRotatable _rotator;
        private Joystick _joystick;
        private PlayerScanner _playerScanner;
        private Vector2 _moveDirection;

        public void Initialize(IMoveable mover,
            IRotatable rotator,
            Joystick joystick,
            PlayerScanner playerScanner)
        {
            _mover = mover;
            _rotator = rotator;
            _joystick = joystick;
            _playerScanner = playerScanner;
            
            _mover.SetSpeed(_maxSpeed);
        }

        private void Update()
        {
            if (_joystick != null)
                _moveDirection = _joystick.Direction.normalized;
            
            #if UNITY_EDITOR
            _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            #endif
            
            _rotator.Rotate(_moveDirection);
            
            if (Input.GetKeyDown(KeyCode.Space))
                _playerScanner.Scan();
        }
        
        private void FixedUpdate()
        {
            _mover?.Move(_moveDirection);
        }
    }
}