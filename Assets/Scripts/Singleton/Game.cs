using System;
using UnityEngine;

public class Game : MonoBehaviour {
    public static Game Instance { get; private set; }

    [field: SerializeField] public AudioManager audioManager { get; private set; }

    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
