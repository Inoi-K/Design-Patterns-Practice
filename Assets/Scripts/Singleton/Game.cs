using UnityEngine;

namespace Singleton {
    public class Game : MonoBehaviour {
        public static Game Instance { get; private set; }

        [field: SerializeField] public AudioManager AudioManager { get; private set; }
        [field: SerializeField] public ParticleManager ParticleManager { get; private set; }

        void Awake() {
            if (Instance != null) {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
