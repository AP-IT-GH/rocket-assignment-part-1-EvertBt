using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevel : MonoBehaviour
{
    public string levelToLoad;
    void Start()
    {
        if (levelToLoad == "")
        {
            levelToLoad = "Level_2";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {   
             SceneManager.LoadScene(levelToLoad);            
        }
    }
}
