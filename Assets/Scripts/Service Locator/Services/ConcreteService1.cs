using System;
using UnityEngine;

namespace ServiceLocator {
    public class ConcreteService1 : MonoBehaviour, IService {
        void OnEnable() {
            ServiceLocator.Register(this);
        }

        void OnDisable() {
            ServiceLocator.Unregister(this);
        }

        public void ConcreteMethod1() {
            Debug.Log($"{nameof(ConcreteService1)} is working");
        }
    }
}
