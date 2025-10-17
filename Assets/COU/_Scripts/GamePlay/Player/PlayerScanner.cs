using System;
using System.Collections;
using COU.GamePlay;
using UnityEngine;

namespace COU.Player
{
    public class PlayerScanner : MonoBehaviour
    {
        [SerializeField] private float _maxDistance;
        [SerializeField] private LayerMask _scanableLayer;
        [SerializeField] private LineRenderer _lineRenderer;

        private bool _canScan = true;
        
        public event Action<Scanable> OnScanEvent; 
        
        public void Scan()
        {
            if (!_canScan)
                return;
            
            StartCoroutine(ScanRoutine());
        }

        private IEnumerator ScanRoutine()
        {
            _canScan = false;
            
            _lineRenderer.startWidth = 1;
            _lineRenderer.endWidth = 1;
            
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, transform.position + transform.right * _maxDistance);

            var origin = transform.position;
            var direction = transform.right;
            
            var isScanned = false;
            var timer = 0f;
            while (timer < 1)
            {
                timer += Time.deltaTime;
                
                _lineRenderer.startWidth -= Time.deltaTime;
                _lineRenderer.endWidth -= Time.deltaTime;
                
                if (!isScanned)
                {
                    isScanned = true;
                    PerformScan(origin, direction, out var result);
                    if (result != Vector2.zero)
                        _lineRenderer.SetPosition(1, result);
                }
                
                yield return null;
            }

            _lineRenderer.SetPosition(1, transform.position);
            
            _lineRenderer.startWidth = 0f;
            _lineRenderer.endWidth = 0f;
            
            _canScan = true;
        }
        
        private void PerformScan(Vector2 origin, Vector2 direction, out Vector2 result)
        {
            result = Vector2.zero;
            
            var hit = Physics2D.Raycast(origin, direction, _maxDistance, _scanableLayer);

            if (hit.collider == null) return;
            
            if (!hit.transform.TryGetComponent(out Scanable scanable)) return;
            
            result = hit.point;
            OnScanEvent?.Invoke(scanable);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + transform.right * _maxDistance);
        }
    }
}