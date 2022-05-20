using UnityEngine;

public class JumpingActorState : IActorState {
    public void Enter(ActorStateController actor) {
        actor.rb.AddForce(actor.transform.up * actor.JumpForce);
    }

    public void UpdateState(ActorStateController actor) {
        if (Input.GetKeyDown(KeyCode.X)) {
            actor.ChangeState(actor.DivingState);
        }
    }
    
    public void OnTriggerEnter(ActorStateController actor) {
        actor.ChangeState(actor.StandingState);
    }

    public void Exit(ActorStateController actor) {
        
    }
}
