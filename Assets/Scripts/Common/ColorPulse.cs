using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class ColorPulse : MonoBehaviour {
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
        float H = .5f * (Mathf.Sin(Time.time * .5f + timeOffset) + 1f);
        float S = .2f * (Mathf.Sin(Time.time * .8f + timeOffset) + .7f);
        float V = .8f;
        Color newColor = Color.HSVToRGB(H, S, V);
        return newColor;
    }
}
