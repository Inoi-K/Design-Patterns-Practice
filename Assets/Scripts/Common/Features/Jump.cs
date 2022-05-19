using UnityEngine;

public class Jump : MonoBehaviour, IClickable {
    [SerializeField] float jumpForce;
    
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void Click() {
        JumpUp();
    }
    
    void JumpUp() {
        rb.AddForce(jumpForce * transform.up);
    }
}
