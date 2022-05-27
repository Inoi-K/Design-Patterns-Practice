using UnityEngine;
using Random = UnityEngine.Random;

namespace Flyweight {
    public class DummyHeavy : MonoBehaviour {
        int health;
        Vector3 direction;
    
        [SerializeField] float speed = .7f;
        [SerializeField] int damage = 5;
        [SerializeField] int maxHealth = 10;
        [SerializeField] string description = "Bob";
    
        void Awake() {
            direction = new Vector3(Random.value, Random.value, Random.value);
            transform.Translate(direction);
        }

        void Update() {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
