using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocket : MonoBehaviour
{
    [Header("Misc")]
    [SerializeField] int iHeight;
    [SerializeField] int iRange;
    [SerializeField] int iKillScore;
    [SerializeField] GameObject goRocket;

    private bool bShotRocket;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bShotRocket == false)
        {
            if (iKillScore <= gameObject.GetComponent<PlayerInfo>().iPlayerKills)
            {
                GameObject go = Instantiate(goRocket, new Vector3(Random.Range(-iRange, iRange), iHeight, Random.Range(-iRange, iRange)), Quaternion.identity);
                go.GetComponent<Rocket>().goPlayer = gameObject;
                bShotRocket = true;
            }
        }
    }
}
