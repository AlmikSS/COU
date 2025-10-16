using COU.GamePlay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace COU.Player
{
    public class ScannerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private Image _iconImage; 
        [SerializeField] private TMP_Text _descriptionText;
        
        public void ShowInfo(Scanable scanable)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            _nameText.text = scanable.Name;
            _iconImage.sprite = scanable.Icon;
            _descriptionText.text = scanable.Description;
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }
    }
}