using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [Header("Chances")]
    [SerializeField] int iChanceMid;
    [SerializeField] int iChanceMax;

    [Header("Reach")]
    [SerializeField] int iRange;

    public Vector3 v3PatrolPos;

    
    void Update()
    {
        if (Random.Range(0, iChanceMax) <= iChanceMid)
        {
            v3PatrolPos = GetNewPosition(v3PatrolPos);
        }
    }

    private Vector3 GetNewPosition(Vector3 v3)
    {
        v3 = new Vector3(v3.x + Random.Range(-iRange, iRange), transform.position.y, v3.z + Random.Range(-iRange, iRange));
     
        return v3;
    }
}
