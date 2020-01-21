using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOnclick : MonoBehaviour
{
    public void SceneRestart() {
        Time.timeScale = 1;
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    public void Quit() {
        Application.Quit();
    }
}
