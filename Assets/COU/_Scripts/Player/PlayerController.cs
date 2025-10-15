using COU.Interfaces;
using UnityEngine;

namespace COU.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        
        private IMoveable _mover;
        private IRotatable _rotator;
        private Joystick _joystick;

        public void Initialize(IMoveable mover, IRotatable rotator, Joystick joystick)
        {
            _mover = mover;
            _rotator = rotator;
            _joystick = joystick;
            
            _mover.Initialize(_maxSpeed, _acceleration);
        }

        private void Update()
        {
            if (_joystick == null)
                return;
            
            if (_joystick.Direction.magnitude > 0.1f)
                _rotator.Rotate(_joystick.Direction);
        }
        
        private void FixedUpdate()
        {
            if (_mover == null)
                return;
            
            _mover.Move(_joystick.Direction);
        }
    }
}