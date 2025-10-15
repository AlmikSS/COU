using UnityEngine;

namespace COU.GamePlay
{
    [SelectionBase]
    public class PlanetRotator : MonoBehaviour
    {
        [SerializeField] private Transform _pivot;
        [SerializeField] private float _speedAroundPivot;
        [SerializeField] private float _speedAroundAxis;
        
        private float _angle;

        private void FixedUpdate()
        {
            RotateAroundPivot();
            RotateAroundAxis();
        }

        private void RotateAroundPivot()
        {
            if (_pivot == null)
                return;
            
            _angle += _speedAroundPivot * Time.fixedDeltaTime;

            var orbitDirection = new Vector2(
                Mathf.Cos(_angle * Mathf.Deg2Rad),
                Mathf.Sin(_angle * Mathf.Deg2Rad));
            
            var orbitRadius = Vector2.Distance(_pivot.position, transform.position); 
            transform.position = _pivot.position + (Vector3)orbitDirection * orbitRadius;
        }

        private void RotateAroundAxis()
        {
            transform.Rotate(0, 0, _speedAroundAxis * Time.fixedDeltaTime);
        }
    }
}