using UnityEngine;

public class StandingActorState : IActorState {
    float xRotationRange;
    float zRotationRange;

    public void Enter(ActorStateController actor) {
        xRotationRange = Random.Range(0f, 3f);
        zRotationRange = Random.Range(0f, 3f);
    }

    public void UpdateState(ActorStateController actor) {
        //IdleRotation(actor);  // reminds an action from a behavioral animation tree...

        if (Input.GetKeyDown(KeyCode.C)) {
            actor.ChangeState(actor.DuckingState);
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            actor.ChangeState(actor.JumpingState);
        }
    }

    public void OnTriggerEnter(ActorStateController actor) {
        
    }

    public void Exit(ActorStateController actor) {
        
    }

    void IdleRotation(ActorStateController actor) {
        //actor.transform.Rotate(Vector3.up * Time.deltaTime);
        Vector3 newAngle = new Vector3(Mathf.PingPong(Time.time, xRotationRange), 0, Mathf.PingPong(Time.time, zRotationRange));
        Quaternion newRotation = Quaternion.Euler(newAngle);
        actor.transform.rotation = newRotation;
    }
}
