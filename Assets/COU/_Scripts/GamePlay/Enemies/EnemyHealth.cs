using COU.Interfaces;
using UnityEngine;

namespace COU.GamePlay
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        public void TakeDamage(int damage)
        {
            Destroy(gameObject);
        }
    }
}