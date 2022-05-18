using UnityEngine;

public class Jump : MonoBehaviour {
    [SerializeField] float jumpForce;
    
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void JumpUp() {
        rb.AddForce(jumpForce * transform.up);
    }
}
