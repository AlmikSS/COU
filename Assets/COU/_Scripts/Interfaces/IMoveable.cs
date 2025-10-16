using UnityEngine;

namespace COU.Interfaces
{
    public interface IMoveable
    {
        void SetSpeed(float speed);
        void Move(Vector2 direction);
    }
}