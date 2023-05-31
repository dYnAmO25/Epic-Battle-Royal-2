using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateMainScreen : MonoBehaviour
{
    [SerializeField] int iSpeed;

    
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * iSpeed);
    }
}
