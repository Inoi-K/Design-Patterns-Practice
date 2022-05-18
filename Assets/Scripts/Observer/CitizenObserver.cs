using UnityEngine;

public class CitizenObserver : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] float range;
    
    Vector3 targetPoint;
    Vector3 direction;

    bool canWander = true;
    
    void OnEnable() {
        ControllerSubject.OnLeftClick += MoveTo;
    }
    
    void OnDisable() {
        ControllerSubject.OnLeftClick -= MoveTo;
    }

    void Start() {
        ChangeTarget(RandomPointInRange());
    }

    void Update() {
        if (Vector3.Distance(transform.position, targetPoint) < .3f && canWander) {
            ChangeTarget(RandomPointInRange());
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }

    void MoveTo(Vector3 destination) {
        if (Vector3.Distance(transform.position, destination) > range)
            return;
        
        canWander = false;
        ChangeTarget(destination);
    }

    void ChangeTarget(Vector3 destination) {
        targetPoint = destination;
        direction = targetPoint - transform.position;
    }
    
    Vector3 RandomPointInRange() {
        return transform.position + new Vector3(Random.value, 0, Random.value) * range;
    }
}
