using UnityEngine;

namespace COU.GamePlay
{
    public class Scanable : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _description;

        public string Name => _name;
        public Sprite Icon => _icon;
        public string Description => _description;
    }
}