using COU.Interfaces;
using UnityEngine;

namespace COU.GamePlay
{
    public class TransformRotator : IRotatable
    {
        private readonly Transform _transform;
        
        public TransformRotator(Transform transform)
        {
            _transform = transform;
        }
        
        public void Rotate(Vector2 direction)
        {
            var x = direction.x;
            var y = direction.y;
            
            var angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}