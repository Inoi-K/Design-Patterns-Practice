using UnityEngine;

namespace Prototype {
    public class Cube : Prototype {
        MaterialPropertyBlock propertyBlock;
        Renderer rend;

        void OnEnable() {
            propertyBlock = new MaterialPropertyBlock();
            rend = GetComponent<Renderer>();
        }

        public override GameObject Clone(Vector3 position) {
            rend.GetPropertyBlock(propertyBlock);
        
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = position;
            obj.transform.rotation = transform.rotation;
            obj.transform.localScale = transform.localScale;
            obj.GetComponent<Renderer>().SetPropertyBlock(propertyBlock);
        
            return obj;
        }
    }
}
