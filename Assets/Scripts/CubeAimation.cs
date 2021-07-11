using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAimation : MonoBehaviour
{
    public void triggerAnimation()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        Debug.Log("Hello");
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
