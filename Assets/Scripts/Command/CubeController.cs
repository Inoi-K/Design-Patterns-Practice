using System.Collections;
using UnityEngine;

namespace Command {
    public class CubeController : ActorController {
        [SerializeField] float speed;
        
        bool isMoving;

        public override void Move(int xDelta, int yDelta) {
            if (isMoving)
                return;
        
            Vector3 direction = new Vector3(xDelta, 0, yDelta);
            StartCoroutine(Roll(direction));
        }

        IEnumerator Roll(Vector3 direction) {
            isMoving = true;
            
            Vector3 rotationCenter = transform.position + Vector3.down / 2 + direction / 2;
            Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

            float remainingAngle = 90;
            while (remainingAngle > 0) {
                float rotationAngle = Mathf.Min(speed * Time.deltaTime, remainingAngle);
                transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
                remainingAngle -= rotationAngle;
                yield return null;
            }
            
            isMoving = false;
        }
    }
}
