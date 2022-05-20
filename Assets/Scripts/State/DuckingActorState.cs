using UnityEngine;

public class DuckingActorState : IActorState {
    float chargeDuration;

    // put crouching in functions later
    public void Enter(ActorStateController actor) {
        Vector3 newPosition = actor.transform.position;
        newPosition.y -= .5f; // hard-coded - bad
        actor.transform.position = newPosition;
    }

    public void UpdateState(ActorStateController actor) {
        if (Input.GetKeyUp(KeyCode.C)) {
            IActorState newState = chargeDuration > actor.requiredChargeDuration ? actor.jumpingState : actor.standingState;
            actor.ChangeState(newState);
        }
    }

    public void Exit(ActorStateController actor) {
        Vector3 newPosition = actor.transform.position;
        newPosition.y += .5f; // hard-coded - bad
        actor.transform.position = newPosition;
    }
}
