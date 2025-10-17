using UnityEngine;

namespace COU.Player
{
    public class PlayerStatsUI : MonoBehaviour
    {
        [SerializeField] private Transform _healthBar;
        [SerializeField] private GameObject _healthSegmentPrefab;
        
        private PlayerHealth _playerHealth;
        
        public void Initialize(PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
            _playerHealth.TakeDamageEvent += OnTakeDamage;
            
            InitializeHealthBar();
        }

        private void InitializeHealthBar()
        {
            for (var i = 0; i < _playerHealth.MaxHealth; i++)
            {
                Instantiate(_healthSegmentPrefab, _healthBar);
            }
        }
        
        private void OnTakeDamage()
        {
            var obj = _healthBar.GetChild(0);
            if (obj != null)
                Destroy(obj.gameObject);
        }
    }
}