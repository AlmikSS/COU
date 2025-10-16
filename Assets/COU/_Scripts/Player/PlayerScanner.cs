using System;
using COU.GamePlay;
using UnityEngine;

namespace COU.Player
{
    public class PlayerScanner : MonoBehaviour
    {
        [SerializeField] private float _maxDistance;
        [SerializeField] private LayerMask _scanableLayer;

        public event Action<Scanable> OnScanEvent; 
        
        public void Scan()
        {
            Debug.Log("Scanning");
            
            Vector2 origin = transform.position;
            Vector2 direction = transform.right.normalized;
            var hit = Physics2D.Raycast(origin, direction, _maxDistance, _scanableLayer);

            if (hit.collider == null) return;
            
            if (!hit.transform.TryGetComponent(out Scanable scanable)) return;
            
            Debug.Log(hit.transform.name);
            OnScanEvent?.Invoke(scanable);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + transform.right * _maxDistance);
        }
    }
}