using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupGem : MonoBehaviour
{
    private Text Score;
    private bool check = true;

    private void Start()
    {
        Score = GameObject.Find("Score").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {        
        Destroy(gameObject);
        if (check)
        {
            check = false;
            int newScore = int.Parse(Score.text) + 1;
            Score.text = newScore.ToString();
        }        
    }
}
