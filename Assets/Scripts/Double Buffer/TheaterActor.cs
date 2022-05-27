using UnityEngine;

namespace DoubleBuffer {
    public class TheaterActor : MonoBehaviour {
        public string nickname;
    
        public bool currentSlapped { get; private set; }
        bool nextSlapped;

        public virtual void React() {}

        public void GetSlapped() {
            nextSlapped = true;
        }
    
        public void Swap() {
            currentSlapped = nextSlapped;
            nextSlapped = false;
        }
    }
}
