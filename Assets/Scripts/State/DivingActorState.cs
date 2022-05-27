namespace State {
    public class DivingActorState : IActorState {
        public void Enter(ActorStateController actor) {
            actor.rb.AddForce(actor.transform.up * -actor.JumpForce);
        }

        public void UpdateState(ActorStateController actor) {
        
        }
    
        public void OnTriggerEnter(ActorStateController actor) {
            actor.ChangeState(actor.StandingState);
        }

        public void Exit(ActorStateController actor) {
        
        }
    }
}
