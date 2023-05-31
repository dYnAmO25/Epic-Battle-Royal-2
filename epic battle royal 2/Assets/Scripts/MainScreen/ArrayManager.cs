using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayManager : MonoBehaviour
{
    [SerializeField] GameObject[] aArrays;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aArrays = GameObject.FindGameObjectsWithTag("Array");

        if (aArrays.Length > 1)
        {
            Destroy(aArrays[0]);
        }
    }
}
