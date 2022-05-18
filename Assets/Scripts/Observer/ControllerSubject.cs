using System;
using UnityEngine;

public class ControllerSubject : MonoBehaviour {
    public static event Action<Vector3> OnLeftClick;
    public static event Action<Vector3> OnRightClick;

    [SerializeField] Material gold;
    [SerializeField] Material decoy;
    
    void Update() {
        ManageInput();
    }
    
    void ManageInput() {
        if (Input.GetMouseButtonDown(0)) {
            ManageClick(OnLeftClick, gold);
        } else if (Input.GetMouseButtonDown(1)) {
            ManageClick(OnRightClick, decoy);
        }
    }

    void ManageClick(Action<Vector3> action, Material collisionPointMaterial) {
        Vector3 mousePositionWorld = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePositionWorld);
        if (Physics.Raycast(ray, out var hitInfoCam, 10000)) {
            Vector3 collisionPoint = hitInfoCam.point;
            
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.transform.position = collisionPoint;
            obj.GetComponent<MeshRenderer>().material = collisionPointMaterial;
            
            action?.Invoke(collisionPoint);
        }
    }
}
