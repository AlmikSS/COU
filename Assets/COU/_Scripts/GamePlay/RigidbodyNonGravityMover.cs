using COU.Interfaces;
using UnityEngine;

namespace COU.GamePlay
{
    public class RigidbodyNonGravityMover : IMoveable
    {
        private readonly float _speed;
        private readonly Rigidbody2D _rb;

        public RigidbodyNonGravityMover(Rigidbody2D rb, float speed)
        {
            _speed = speed;
            _rb = rb;
        }

        public void Move(Vector2 direction)
        {
            _rb.AddForce(direction * _speed);
        }
    }
}