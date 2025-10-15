using COU.Interfaces;
using UnityEngine;

namespace COU.GamePlay
{
    public class RigidbodyNonGravityMover : IMoveable
    {
        private readonly Rigidbody2D _rb;
        private float _acceleration;
        private float _maxSpeed;

        public RigidbodyNonGravityMover(Rigidbody2D rb)
        {
            _rb = rb;
        }

        public void Initialize(float speed, float acceleration)
        {
            _maxSpeed = speed;
            _acceleration = acceleration;
        }
        
        public void Move(Vector2 direction)
        {
            var targetVelocity = direction.normalized * _maxSpeed;
            var currentVelocity = _rb.linearVelocity;
        
            var newVelocity = Vector2.MoveTowards(
                currentVelocity, 
                targetVelocity, 
                _acceleration * Time.fixedDeltaTime
            );
        
            _rb.linearVelocity = newVelocity;
        }
    }
}