using UnityEngine;

namespace COU.GamePlay
{
    [SelectionBase]
    public class PlanetRotator : MonoBehaviour
    {
        [SerializeField] private Transform _pivot;
        [SerializeField] private float _speedAroundPivot;
        [SerializeField] private float _speedAroundAxis;
        [SerializeField] private bool _drawOrbit = true;
        [SerializeField] private LineRenderer _orbitLine;
        [SerializeField] private int _orbitPoints = 360;
        
        private float _angle;
        private float _orbitRadius;

        private void Start()
        {
            if (_pivot == null) return;
            
            if (!_drawOrbit)
                return;
            
            _orbitRadius = Vector2.Distance(_pivot.position, transform.position);
            DrawOrbit();
        }

        private void DrawOrbit()
        {
            if (_orbitLine == null) return;

            _orbitLine.positionCount = _orbitPoints + 1;
            _orbitLine.loop = true;
            _orbitLine.useWorldSpace = true;

            for (var i = 0; i <= _orbitPoints; i++)
            {
                var angle = (float)i / _orbitPoints * 360f * Mathf.Deg2Rad;
                var point = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * _orbitRadius;
                _orbitLine.SetPosition(i, _pivot.position + (Vector3)point);
            }
        }
        
        private void FixedUpdate()
        {
            RotateAroundPivot();
            RotateAroundAxis();
        }

        private void RotateAroundPivot()
        {
            if (_pivot == null)
                return;
            
            var orbitRadius = Vector2.Distance(_pivot.position, transform.position);
            var orbitalSpeed = _speedAroundPivot / Mathf.Sqrt(orbitRadius);
    
            _angle += orbitalSpeed * Time.fixedDeltaTime;

            var orbitDirection = new Vector2(
                Mathf.Cos(_angle * Mathf.Deg2Rad),
                Mathf.Sin(_angle * Mathf.Deg2Rad));
    
            transform.position = _pivot.position + (Vector3)orbitDirection * orbitRadius;
        }

        private void RotateAroundAxis()
        {
            transform.Rotate(0, 0, _speedAroundAxis * Time.fixedDeltaTime);
        }
    }
}