using UnityEngine;

namespace ServiceLocator {
    public class ConcreteService2 : MonoBehaviour, IService {
        void OnEnable() {
            ServiceLocator.Register(this);
        }

        void OnDisable() {
            ServiceLocator.Unregister(this);
        }
        
        public void ConcreteMethod2() {
            Debug.Log($"{nameof(ConcreteService2)} is working");
        }
    }
}
