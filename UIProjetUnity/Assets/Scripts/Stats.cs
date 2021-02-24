using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "new_stat", menuName = "Stat", order = 0)]
    public class Stats : ScriptableObject
    {
        private float battery;
        private float health;
        private bool ownKey1;
        private bool ownKey2;
        
        public float Battery
        {
            get => battery;
            set => battery = value;
        }

        public float Health
        {
            get => health;
            set => health = value;
        }

        public bool OwnKey1
        {
            get => ownKey1;
            set => ownKey1 = value;
        }

        public bool OwnKey2
        {
            get => ownKey2;
            set => ownKey2 = value;
        }
    }
}