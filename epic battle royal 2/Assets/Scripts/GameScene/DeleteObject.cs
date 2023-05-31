using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    [SerializeField] float fTime;

    void Start()
    {
        Invoke("DeleteObj", fTime);
    }

    public void DeleteObj()
    {
        Destroy(gameObject);
    }
}
