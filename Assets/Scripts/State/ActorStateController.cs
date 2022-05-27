using UnityEngine;

namespace State {
    public class ActorStateController : MonoBehaviour {
        [SerializeField] ParticleSystem successChargeEffect;

        // they should be readonly-like, let's just ignore that for now
        [field: SerializeField] public float RequiredChargeDuration { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField] public Vector3 DuckingScale { get; private set; }
    
        IActorState currentState;
        public readonly IActorState StandingState = new StandingActorState();
        public readonly IActorState DuckingState = new DuckingActorState();
        public readonly IActorState JumpingState = new JumpingActorState();
        public readonly IActorState DivingState = new DivingActorState();
    
        public Rigidbody rb { get; private set; }

        void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        void OnEnable() {
            currentState = StandingState;
            currentState.Enter(this);
        }

        void Update() {
            currentState.UpdateState(this);
            print(currentState);
        }

        void OnTriggerEnter(Collider other) {
            currentState.OnTriggerEnter(this);
        }

        public void ChangeState(IActorState newState) {
            currentState.Exit(this);
            currentState = newState;
            currentState.Enter(this);
        }

        public void ShowEffect() {
            successChargeEffect.Play();
        }
    }
}
