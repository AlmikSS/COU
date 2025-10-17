using UnityEngine;

namespace COU.Interfaces
{
    public interface IPathfinder
    {
        Vector2 GetDirection(Vector2 start, Vector2 end);
    }
}