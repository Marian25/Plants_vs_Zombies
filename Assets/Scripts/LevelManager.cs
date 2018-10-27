using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    // parameters
    [SerializeField] float autoLoadNextLevelAfter;

    private void Start() {
        Invoke("LoadNextLevel", autoLoadNextLevelAfter);
    }

    public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest() {
        Application.Quit();
    }

    public void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
