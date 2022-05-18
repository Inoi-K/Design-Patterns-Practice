using UnityEngine;

public class SpawnerPrototype : MonoBehaviour {
    [SerializeField] Prototype prototypeInstance;
    
    [SerializeField] [Range(1, 10)] int clonesAmount;
    
    public void ClonePrototype() {
        for (int i = 0; i < clonesAmount; ++i) {
            GameObject clone = prototypeInstance.Clone(transform.position);
            clone.AddComponent<Rigidbody>();
            Lifetime lifetimeComp = clone.AddComponent<Lifetime>();
            lifetimeComp.lifetime = 5f;
        }
    }
}
