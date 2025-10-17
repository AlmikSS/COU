using System.Collections.Generic;
using COU.Interfaces;
using UnityEngine;

namespace COU.GamePlay
{
    public class PotentialFieldPathfinder : IPathfinder
    {
        private readonly List<Transform> _planets;
        private float _attractionStrength;
        private float _repulsionStrength;
        private float _safeDistance;

        public PotentialFieldPathfinder(List<Transform> planets)
        {
            _planets = planets;
        }

        public Vector2 GetDirection(Vector2 start, Vector2 end)
        {
            var direction = (end - start).normalized;
            var attractionForce = direction * _attractionStrength;
            var repulsionForce = new Vector2();

            foreach (var planet in _planets)
            {
                var directionFromPlanet = (start - (Vector2)planet.position).normalized;
                var distance = Vector2.Distance(start, planet.position);

                if (distance < _safeDistance)
                {
                    var strength = 1 - (distance / _safeDistance);
                    repulsionForce += directionFromPlanet * strength;
                }
            }

            var totalForce = attractionForce + repulsionForce * _repulsionStrength;
            return totalForce.normalized;
        }
    }
}