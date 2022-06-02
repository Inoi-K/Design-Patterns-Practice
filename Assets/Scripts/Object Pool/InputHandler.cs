using UnityEngine;

namespace ObjectPool {
    public class InputHandler : MonoBehaviour {
        [SerializeField] GameObject prefab1;
        [SerializeField] GameObject prefab2;

        void Start() {
            PoolManager.Instance.CreatePool(prefab1);
            PoolManager.Instance.CreatePool(prefab2);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                PoolManager.Instance.ReuseObject(prefab1, Vector3.zero, Quaternion.identity);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                PoolManager.Instance.ReuseObject(prefab2, Vector3.zero, Quaternion.identity);
            }
        }
    }
}
