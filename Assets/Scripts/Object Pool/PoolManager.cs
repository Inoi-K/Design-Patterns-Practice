using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool {
    public class PoolManager : MonoBehaviour {
        public static PoolManager Instance { get; private set; }
    
        Dictionary<int, Queue<ObjectInstance>> poolDictionary = new();

        const int MAX_POOL_SIZE = 10000;
        
        void Awake() {
            if (Instance != null) {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
     
        public void CreatePool(GameObject prefab, int poolSize = MAX_POOL_SIZE) {
            int poolKey = prefab.GetInstanceID();

            Transform poolHolder = new GameObject($"{prefab.name} Pool").transform;
            poolHolder.parent = transform;
            
            if (!poolDictionary.ContainsKey(poolKey)) {
                poolDictionary.Add(poolKey, new Queue<ObjectInstance>());

                for (int i = 0; i < poolSize; ++i) {
                    ObjectInstance newObject = new ObjectInstance(Instantiate(prefab), poolHolder);
                    poolDictionary[poolKey].Enqueue(newObject);
                }
            }
        }

        public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation) {
            int poolKey = prefab.GetInstanceID();

            if (poolDictionary.ContainsKey(poolKey)) {
                ObjectInstance objectToReuse = poolDictionary[poolKey].Dequeue();
                poolDictionary[poolKey].Enqueue(objectToReuse);
                
                objectToReuse.Reuse(position, rotation);
            }
        }

        class ObjectInstance {
            readonly GameObject gameObject;
            readonly Transform transform;
            readonly IPoolObject poolPart;

            public ObjectInstance(GameObject objectInstance, Transform parent = null) {
                gameObject = objectInstance;
                transform = objectInstance.transform;
                poolPart = objectInstance.GetComponent<IPoolObject>();
                
                gameObject.SetActive(false);
                if (parent != null)
                    transform.parent = parent;
            }

            public void Reuse(Vector3 position, Quaternion rotation) {
                transform.position = position;
                transform.rotation = rotation;
                gameObject.SetActive(true);
                poolPart?.Reset(); // in this case, it should be after activation due to the coroutine in the projectile script
            }
        }
    }
}
