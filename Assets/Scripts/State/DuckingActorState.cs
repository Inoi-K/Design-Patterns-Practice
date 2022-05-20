using UnityEngine;

public class DuckingActorState : IActorState {
    float chargeDuration;
    bool isCharged;
    
    Vector3 originalScale;
    
    public void Enter(ActorStateController actor) {
        chargeDuration = 0;
        isCharged = false;
        originalScale = actor.transform.localScale;
        
        actor.rb.useGravity = false;
        actor.transform.localScale = actor.DuckingScale;
    }

    // perhaps, there could be placed a state for a charged condition
    public void UpdateState(ActorStateController actor) {
        if (Input.GetKeyUp(KeyCode.C)) {
            IActorState newState = isCharged ? actor.JumpingState : actor.StandingState;
            actor.ChangeState(newState);
            return;
        }
        
        if (!isCharged && chargeDuration > actor.RequiredChargeDuration) {
            isCharged = true;
            actor.ShowEffect();
        }
        
        chargeDuration += Time.deltaTime;
    }
    
    public void OnTriggerEnter(ActorStateController actor) {
        
    }

    public void Exit(ActorStateController actor) {
        actor.transform.localScale = originalScale;
        actor.rb.useGravity = true;
    }
}
