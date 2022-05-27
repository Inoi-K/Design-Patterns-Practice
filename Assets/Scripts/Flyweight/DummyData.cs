using UnityEngine;

namespace Flyweight {
    [CreateAssetMenu(fileName = "DummyData", menuName = "Flyweight/DummyData")]
    public class DummyData : ScriptableObject {
        public float speed;
        public int damage;
        public int maxHealth;
        public string description;
    }
}
