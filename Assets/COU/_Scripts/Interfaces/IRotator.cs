using UnityEngine;

namespace COU.Interfaces
{
    public interface IRotator
    {
        void SetSpeed(float speed);
        void Rotate(Vector2 direction);
    }
}