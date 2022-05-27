using UnityEngine;

namespace TypeObject {
    [CreateAssetMenu(fileName = "Breed", menuName = "Type Object/Breed")]
    public class Breed : ScriptableObject {
        [field: SerializeField] public string Kin { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public string AttackText { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
    }
}
