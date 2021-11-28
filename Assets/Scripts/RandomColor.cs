using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Renderer objectRenderer = gameObject.GetComponent<Renderer>();
        objectRenderer.material.color = new Color(Random.Range(10f,255f)/255f, Random.Range(10f, 255f)/255f, Random.Range(10f, 255f)/255f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
