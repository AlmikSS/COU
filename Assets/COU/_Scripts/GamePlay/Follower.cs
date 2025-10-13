using UnityEngine;

namespace COU.GamePlay
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _smoothTime = 0.1f;
        [SerializeField] private Vector3 _offset;

        private void LateUpdate()
        {
            if (_target == null) return;
    
            var targetPosition = _target.position + _offset;
            transform.position = Vector3.Lerp(
                transform.position, 
                targetPosition, 
                Time.deltaTime * (1f / _smoothTime)
            );
        }
    }
}