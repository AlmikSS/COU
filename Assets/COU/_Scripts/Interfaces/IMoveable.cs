using UnityEngine;

namespace COU.Interfaces
{
    public interface IMoveable
    {
        void Initialize(float speed, float acceleration);
        void Move(Vector2 direction);
    }
}