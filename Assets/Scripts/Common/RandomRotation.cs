using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomRotation : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] Vector3 rotationDirection;

    void OnEnable() {
        rotationDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
            );
        rotationDirection = rotationDirection.normalized;
    }

    void Update() {
        transform.Rotate(rotationDirection * speed * Time.deltaTime);
    }
}
