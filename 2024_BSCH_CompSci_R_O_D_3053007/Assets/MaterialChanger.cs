using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MaterialChanger : MonoBehaviour
{
    public Material testMat;
    // Start is called before the first frame update
    void Start()
    {   // assigning the Material from the gameobject's Mesh Render Component to the testMat variable
        testMat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        testMat.color = Random.ColorHSV();

    }
}
