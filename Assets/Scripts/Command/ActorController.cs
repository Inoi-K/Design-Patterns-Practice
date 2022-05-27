using UnityEngine;

namespace Command {
    public class ActorController : MonoBehaviour {
        public int xPosition { get; private set; }
        public int yPosition { get; private set; }

        public virtual void Move(int xDelta, int yDelta) {
            xPosition += xDelta;
            yPosition += yDelta;
        }
    }
}
