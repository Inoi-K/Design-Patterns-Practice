using UnityEngine;

namespace TypeObject {
    public class Target : MonoBehaviour {
        [SerializeField] int health;
        public void TakeDamage(int damage) {
            health -= damage;
        }
    }
}
