using Singleton;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public void ChangeMusic() {
        Game.Instance.AudioManager.PlayRandomMusic();
    }
}
