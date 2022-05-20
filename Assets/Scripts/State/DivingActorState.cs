using UnityEngine;

public class DivingActorState : IActorState {
    public void Enter(ActorStateController actor) {
        actor.rb.AddForce(Vector3.one * -actor.jumpForce);
    }

    public void UpdateState(ActorStateController actor) {
        if (actor.isGrounded) {
            actor.ChangeState(actor.standingState);
        }
    }

    public void Exit(ActorStateController actor) {
        
    }
}
