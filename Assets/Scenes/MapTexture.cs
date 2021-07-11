using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTexture : MonoBehaviour
{
    private MeshFilter cubeMesh;
    private Mesh mesh;
    
    // Start is called before the first frame update
    void Start()
    {
        cubeMesh = GetComponent<MeshFilter>();
        mesh = cubeMesh.mesh;
        Vector2[] uvMap = mesh.uv;
        
        //front
        uvMap[0] = new Vector2(0, 0);
        uvMap[1] = new Vector2(0.333f, 0);
        uvMap[2] = new Vector2(0, 0.333f);
        uvMap[3] = new Vector2(0.333f, 0.333f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
