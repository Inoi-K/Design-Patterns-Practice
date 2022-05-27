using UnityEngine;

namespace TypeObject {
    public class Monster : MonoBehaviour {
        [SerializeField] Breed breed;
        [SerializeField] LayerMask enemyLayer;
        
        int health;

        void OnEnable() {
            health = breed.MaxHealth;
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                Attack();
            }
        }

        void Attack() {
            Collider[] targets = Physics.OverlapSphere(transform.position, breed.AttackRange, enemyLayer);
            foreach (var target in targets) {
                Target obj = target.GetComponent<Target>();
                obj.TakeDamage(breed.Damage);
                Debug.Log($"{breed.Kin} dealt {breed.AttackText} {breed.Damage} damage to the target at {obj.transform.position}");
            }
        }
    }
}
