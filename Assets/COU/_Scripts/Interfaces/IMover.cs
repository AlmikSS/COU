using UnityEngine;

namespace COU.Interfaces
{
    public interface IMover
    {
        void SetSpeed(float speed);
        void Move(Vector2 direction);
        void Stop();
    }
}