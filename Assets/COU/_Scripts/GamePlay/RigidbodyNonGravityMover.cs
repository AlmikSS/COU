using COU.Interfaces;
using UnityEngine;

namespace COU.GamePlay
{
    public class RigidbodyNonGravityMover : IMoveable
    {
        private readonly float _acceleration;
        private readonly float _maxSpeed;
        private readonly Rigidbody2D _rb;

        public RigidbodyNonGravityMover(float acceleration, float maxSpeed, Rigidbody2D rb)
        {
            _acceleration = acceleration;
            _maxSpeed = maxSpeed;
            _rb = rb;
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