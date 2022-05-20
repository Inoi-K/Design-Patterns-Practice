using System;
using UnityEngine;

public class ActorStateController : MonoBehaviour {
    IActorState currentState;

    // they should be readonly-like, let's just ignore that for now
    public float requiredChargeDuration;
    public float jumpForce;
    [HideInInspector] public bool isGrounded;
    
    public readonly IActorState standingState = new StandingActorState();
    public readonly IActorState duckingState = new DuckingActorState();
    public readonly IActorState jumpingState = new JumpingActorState();
    public readonly IActorState divingState = new DivingActorState();
    
    public Rigidbody rb { get; private set; }

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void ChangeState(IActorState newState) {
        currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    void OnTriggerEnter(Collider other) {
        isGrounded = true;
    }

    void OnTriggerExit(Collider other) {
        isGrounded = false;
    }
}
