using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour {
    public void LoadMainScene() {
        LoadScene(Tags.MainScene);
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
