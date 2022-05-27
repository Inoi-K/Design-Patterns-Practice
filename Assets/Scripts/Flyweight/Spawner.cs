using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Flyweight {
    public class Spawner : MonoBehaviour {
        enum PrefabType { Heavy, Flyweight }

        [SerializeField] PrefabType prefabType;
        [SerializeField] Vector3 spawnLimits;
        [SerializeField] int instancesToSpawn = 5000;
   
        [SerializeField] GameObject prefabHeavy;
        [SerializeField] GameObject prefabFlyweight;
        [SerializeField] DummyData data;

        void Start() {
            Spawn(1);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Spawn(instancesToSpawn);
            }
        }

        void Spawn(int count) {
            switch (prefabType) {
                case PrefabType.Heavy:
                    for (int i = 0; i < count; ++i)
                        SpawnRandom(prefabHeavy);
                    break;
                case PrefabType.Flyweight:
                    for (int i = 0; i < count; ++i) {
                        DummyFlyweight flyweight = SpawnRandom(prefabFlyweight).GetComponent<DummyFlyweight>();
                        flyweight.SetData(data);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        GameObject SpawnRandom(GameObject objectToSpawn) {
            Vector3 position = new Vector3(Random.Range(-spawnLimits.x, spawnLimits.x),
                Random.Range(0, spawnLimits.y * 2), Random.Range(-spawnLimits.z, spawnLimits.z));
            return SpawnAt(objectToSpawn, position);
        }

        GameObject SpawnAt(GameObject objectToSpawn, Vector3 position) {
            return Instantiate(objectToSpawn, position, Quaternion.identity, transform);
        }
    
        void OnDrawGizmos() {
            Gizmos.DrawWireCube(new Vector3(0, spawnLimits.y, 0), spawnLimits * 2);
        }
    }
}
