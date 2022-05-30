using UnityEngine;

namespace ServiceLocator {
    public class Game : MonoBehaviour {
        void Awake() {
            ServiceLocator.Initialize();
        }

        void Start() {
            ServiceLocator.GetService<ConcreteService1>().ConcreteMethod1();
            ServiceLocator.GetService<ConcreteService2>().ConcreteMethod2();
            ServiceLocator.GetService<ConcreteService3>().ConcreteMethod3();
        }
    }
}
