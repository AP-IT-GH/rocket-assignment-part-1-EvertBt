using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowEndCanvas : MonoBehaviour
{
    public Canvas endCanvas;
    public Text finalScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            endCanvas.gameObject.SetActive(true);
            finalScore = GameObject.Find("FinalScore").GetComponent<Text>();
            finalScore.text = "Score: " + GameObject.Find("Score").GetComponent<Text>().text;
            GameManager.state = GameManager.GameState.Finished;
        }
    }
}
