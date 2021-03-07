using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "new_stat", menuName = "Stat", order = 0)]
    public class Stats : ScriptableObject
    {
        private float battery; // Valeur de la batterie
        private float health; // Valeur de la vie
        private bool ownKey1; // Possession de la clé 1
        private bool ownKey2; // Possession de la clé 3
        private bool ownKey3; // Possession de la clé 3

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

        public bool OwnKey3
        {
            get => ownKey3;
            set => ownKey3 = value;
        }

    }
}