using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelLoad : MonoBehaviour
{
    public string mLevelToLoad;

    public void loadLevel()
    {
        HealthManager.Health = 0;
        GameManager.state = GameManager.GameState.Playing;
        SceneManager.LoadScene(mLevelToLoad);
    }
}
