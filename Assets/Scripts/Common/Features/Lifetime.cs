using System;
using UnityEngine;

public class Lifetime : MonoBehaviour {
    public float lifetime;

    void Start() {
        Invoke(nameof(Remove), lifetime);
    }

    void Remove() {
        Destroy(gameObject);
    }
}
