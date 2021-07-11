using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : MonoBehaviour
{
    public GameObject Parent;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Parent.transform.position ;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Parent.transform.position + offset;
    }

    private void LateUpdate()
    {
        
    }
}
