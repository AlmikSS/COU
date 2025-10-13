using COU.GamePlay;
using COU.Interfaces;
using UnityEngine;

namespace COU.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        
        private IMoveable _mover;
        private IRotatable _rotator;

        private void Awake()
        {
            var rb = GetComponent<Rigidbody2D>();
            _mover = new RigidbodyNonGravityMover(_acceleration, _maxSpeed, rb);
            _rotator = new TransformRotator(transform);
        }

        private void Update()
        {
            if (_joystick.Direction.magnitude > 0.1f)
                _rotator.Rotate(_joystick.Direction);
        }
        
        private void FixedUpdate()
        {
            _mover.Move(_joystick.Direction);
        }
    }
}