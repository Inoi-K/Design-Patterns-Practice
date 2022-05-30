using UnityEngine;

namespace ServiceLocator {
    public class ConcreteService3 : MonoBehaviour, IService {
        void OnEnable() {
            ServiceLocator.Register(this);
        }

        void OnDisable() {
            ServiceLocator.Unregister(this);
        }
        
        public void ConcreteMethod3() {
            Debug.Log($"{nameof(ConcreteService3)} is working");
        }
    }
}
