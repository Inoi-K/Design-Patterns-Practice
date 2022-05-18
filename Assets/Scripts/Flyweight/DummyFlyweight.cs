using UnityEngine;

public class DummyFlyweight : MonoBehaviour {
    int health;
    Vector3 direction;
    DummyData data;
    
    void Awake() {
        direction = new Vector3(Random.value, Random.value, Random.value);
        transform.Translate(direction);
    }
    
    void Update() {
        transform.Translate(direction * data.speed * Time.deltaTime);
    }

    public void SetData(DummyData data) {
        this.data = data;
    }
}
