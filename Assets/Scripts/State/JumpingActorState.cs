using UnityEngine;

public class JumpingActorState : IActorState {
    public void Enter(ActorStateController actor) {
        actor.rb.AddForce(Vector3.up * actor.jumpForce);
    }

    public void UpdateState(ActorStateController actor) {
        if (Input.GetKeyDown(KeyCode.X)) {
            actor.ChangeState(actor.divingState);
        }

        // change to OnTriggerEnter function inside this state
        if (actor.isGrounded) {
            actor.ChangeState(actor.standingState);
        }
    }

    public void Exit(ActorStateController actor) {
        
    }
}
