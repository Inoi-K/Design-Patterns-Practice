using System.Collections;
using UnityEngine;

namespace ObjectPool {
    public class Projectile : MonoBehaviour, IPoolObject {
        [SerializeField] float moveSpeed;
        [SerializeField] float scaleSpeed;

        TrailRenderer trail;
        float trailTime;

        void Awake() {
            trail = GetComponent<TrailRenderer>();
            trailTime = trail.time;
        }

        void Update() {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.localScale += Vector3.one * Time.deltaTime * scaleSpeed;
        }

        public void Reset() {
            transform.localScale = Vector3.one;
            StartCoroutine(ResetTrail());
        }

        IEnumerator ResetTrail() {
            trail.time = -1;
            
            yield return null;
            
            trail.time = trailTime;
        }
    }
}
