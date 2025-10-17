using COU.Interfaces;
using UnityEngine;

namespace COU.GamePlay
{
    public class PotentialFieldPathfinder : IPathfinder
    {
        private readonly float _repulsionStrength;
        private readonly LayerMask _obstacleLayerMask;

        public PotentialFieldPathfinder(float repulsionStrength, LayerMask obstacleLayerMask)
        {
            _repulsionStrength = repulsionStrength;
            _obstacleLayerMask = obstacleLayerMask;
        }
        
        public Vector2 GetDirection(Vector2 start, Vector2 end)
        {
            var baseDirection = (end - start).normalized;
            
            if (!Physics2D.Raycast(start, baseDirection, Vector2.Distance(start, end), _obstacleLayerMask))
            {
                return baseDirection;
            }

            var perpendicular = new Vector2(-baseDirection.y, baseDirection.x);
            var adjustedDirection = (baseDirection + perpendicular * _repulsionStrength).normalized;
            
            return adjustedDirection;
        }
    }
}