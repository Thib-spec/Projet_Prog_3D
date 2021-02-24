using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "new_stat", menuName = "Stat", order = 0)]
    public class Stats : ScriptableObject
    {
        private float battery;
        private float health;
        
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
    }
}