using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string Name;
    public Vector3 oldPosition;
    // Start is called before the first frame update
    void Start()
    {
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
