using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNewTarget : MonoBehaviour
{
    public GameObject goTarget;
    
    public void SetTarget()
    {
        if (goTarget != null)
        {
            GameObject.FindGameObjectWithTag("CameraMiddle").GetComponent<CameraMovement>().goTargetObject = goTarget;
        }
        else
        {
            Debug.Log("Nenene");
        }
    }
}
