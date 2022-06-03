using System.Collections;
using UnityEngine;

namespace SpatialPartition {
    public class Unit : MonoBehaviour {
        Grid grid;
        [System.NonSerialized] public Unit prev;
        [System.NonSerialized] public Unit next;

        MeshRenderer meshRenderer;
        Color initialColor;

        [SerializeField] Vector2 minMaxMoveSpeed;
        float moveSpeed;
        
        Coroutine currentAttack;
        
        public const float ATTACK_DISTANCE = 1;
        
        public void Init(Grid grid, Vector3 startPosition) {
            this.grid = grid;
            transform.position = startPosition;

            prev = null;
            next = null;
            grid.Add(this);

            meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
            initialColor = meshRenderer.material.color;

            moveSpeed = Random.Range(minMaxMoveSpeed.x, minMaxMoveSpeed.y);
            transform.rotation = GetRandomRotation();
        }

        public void Move(float delta) {
            Vector3 newPosition = transform.position + transform.forward * moveSpeed * delta;

            if (!grid.IsWithinBoundaries(newPosition)) {
                transform.rotation = GetRandomRotation();
                return;
            }

            transform.position = newPosition;
            grid.Move(this, transform.position);
        }

        #region Fighting
        public void Attack() {
            if (currentAttack != null)
                StopCoroutine(currentAttack);
            currentAttack = StartCoroutine(PerformAttack());
        }

        IEnumerator PerformAttack() {
            meshRenderer.sharedMaterial.color = Color.red;

            yield return new WaitForSeconds(1f);

            meshRenderer.sharedMaterial.color = initialColor;
        }
        #endregion

        static Quaternion GetRandomRotation() {
            return Quaternion.Euler(0, Random.Range(0f, 360f), 0f);
        }
    }
}
