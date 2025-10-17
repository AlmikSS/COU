using COU.Interfaces;
using UnityEngine;

namespace COU.GamePlay
{
    public class TransformDirectionRotator : IRotator
    {
        private readonly Transform _transform;
        private float _rotationSpeed = 5f;

        public TransformDirectionRotator(Transform transform)
        {
            _transform = transform;
        }

        public void SetSpeed(float speed)
        {
            _rotationSpeed = speed;
        }
        
        public void Rotate(Vector2 direction)
        {
            if (direction.magnitude < 0.1f) return;

            var targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);

            _transform.rotation = Quaternion.Lerp(
                _transform.rotation,
                targetRotation,
                _rotationSpeed * Time.deltaTime
            );
        }
    }
}