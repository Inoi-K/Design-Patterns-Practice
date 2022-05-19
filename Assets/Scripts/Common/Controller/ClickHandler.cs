using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour {
    [SerializeField] LayerMask clickableMask;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, Camera.main.farClipPlane, clickableMask)) {
                hit.transform.GetComponent<IClickable>()?.Click();
                Game.Instance.audioManager.PlayRandomSound();
            }
        }
    }
}
