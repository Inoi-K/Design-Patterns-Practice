using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pulsate : MonoBehaviour {
    [SerializeField] float minScale;
    
    float timeOffset;

    void OnEnable() {
        timeOffset = Random.Range(0f, 100f);
    }

    void Update() {
        float newScale = Mathf.Max(.5f * (Mathf.Sin(Time.time * .6f + timeOffset) + 1f), .4f);
        transform.localScale = Vector3.one * newScale;
    }
}
