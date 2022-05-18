using UnityEngine;

public class Pulsate : MonoBehaviour {
    [SerializeField, Range(0, 1)] float speed;
    [SerializeField] Vector2 minMaxScale;
    
    float timeOffset;

    void OnEnable() {
        timeOffset = Random.Range(0f, 100f);
    }

    void Update() {
        // Function form: amplitude * (sin(x * angular_frequency + phase) + offset)
        // amplitude - the peak value (in case offset=0)
        // angular_frequency - the lower the absolute value, the smoother the change will be
        // phase - defines the initial value f(0)
        // offset >= 1 - sets the function greater or equal 0
        float newScale = Mathf.Max(minMaxScale.y / 2 * (Mathf.Sin(Time.time * speed + timeOffset) + 1f), minMaxScale.x);
        transform.localScale = Vector3.one * newScale;
    }
}
