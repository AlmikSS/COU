using UnityEngine;

namespace COU.Interfaces
{
    public interface IRotatable
    {
        void SetSpeed(float speed);
        void Rotate(Vector2 direction);
    }
}