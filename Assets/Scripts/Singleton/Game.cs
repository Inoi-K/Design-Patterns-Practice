using System;
using UnityEngine;

public class Game : MonoBehaviour {
    public static Game Instance { get; private set; }

    public AudioManager audioManager;
    
    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
