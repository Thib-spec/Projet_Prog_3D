using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "newItem", menuName = "Item", order = 0)]
    public class Item : ScriptableObject
    {
        public string fullName;
        public Sprite icon;
        public string itemDescription;
        
    }
}