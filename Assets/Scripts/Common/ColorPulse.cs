using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorPulse : MonoBehaviour {
    [SerializeField, Range(0, 1)] float hueSpeed;
    [SerializeField, Range(0, 1)] float saturationSpeed;
    
    float timeOffset;
    MaterialPropertyBlock propertyBlock;
    Renderer rend;

    void Awake() {
        rend = GetComponent<Renderer>();
    }

    void OnEnable() {
        timeOffset = Random.Range(0f, 100f);
        propertyBlock = new MaterialPropertyBlock();
    }

    void Update() {
        Color newColor = RandomColor();
        propertyBlock.SetColor("_Color", newColor);
        rend.SetPropertyBlock(propertyBlock);
    }

    Color RandomColor() {
        // Function form: amplitude * (sin(x * angular_frequency + phase) + offset)
        // amplitude - the peak value (in case offset=0)
        // angular_frequency - the lower the absolute value, the smoother the change will be
        // phase - defines the initial value f(0)
        // offset >= 1 - sets the function greater or equal 0
        float H = .5f * (Mathf.Sin(Time.time * hueSpeed + timeOffset) + 1f);
        float S = .5f * (Mathf.Sin(Time.time * saturationSpeed + timeOffset) + 1f);
        float V = .8f;
        Color newColor = Color.HSVToRGB(H, S, V);
        return newColor;
    }
}
