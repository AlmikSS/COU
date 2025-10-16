using COU.Interfaces;
using UnityEngine;

namespace COU.GamePlay
{
    public class RigidbodyNonGravityMover : IMoveable
    {
        private readonly Rigidbody2D _rb;
        private float _speed;

        public RigidbodyNonGravityMover(Rigidbody2D rb)
        {
            _rb = rb;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
        
        public void Move(Vector2 direction)
        {
            _rb.AddForce(direction.normalized * _speed);
        }
    }
}