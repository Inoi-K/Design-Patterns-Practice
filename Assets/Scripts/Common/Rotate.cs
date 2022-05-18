using UnityEngine;

public class Rotate : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] bool isRandom = true;
    [SerializeField] Vector3 rotationDirection;

    void OnEnable() {
        if (isRandom) {
            rotationDirection = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            );
            rotationDirection = rotationDirection.normalized;
        }
    }

    void Update() {
        transform.Rotate(rotationDirection * speed * Time.deltaTime);
    }
}
