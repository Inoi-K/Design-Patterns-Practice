using UnityEngine;

namespace Prototype {
    public abstract class Prototype : MonoBehaviour {
        public abstract GameObject Clone(Vector3 position);
    }
}
