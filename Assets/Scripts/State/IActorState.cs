public interface IActorState {
    public void Enter(ActorStateController actor);
    public void UpdateState(ActorStateController actor);
    public void OnTriggerEnter(ActorStateController actor);
    public void Exit(ActorStateController actor);
}
