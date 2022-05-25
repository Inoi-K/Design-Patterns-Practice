using UnityEngine;

namespace SubclassSandbox {
    public class HeroController : MonoBehaviour {
        [SerializeField] Superpower superpower1;
        [SerializeField] Superpower superpower2;
        [SerializeField] float speed;
        
        Vector3 targetPosition;

        void Awake() {
            superpower1.Init(this);
            superpower2.Init(this);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                superpower1.Activate();
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                superpower2.Activate();
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        public void Move(Vector3 direction) {
            targetPosition = transform.position + direction;
        }
    }
}
