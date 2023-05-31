using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    [Header("Zones")]
    [SerializeField] GameObject[] goZones;
    [SerializeField] int iTime;
    public int iDamageMultiplyer;

    float f = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (goZones.Length != 0)
        {
            f += Time.deltaTime;

            if (f > iTime)
            {
                f = 0;
                EnableZone();
            }
        }
    }

    private void EnableZone()
    {
        int i = Random.Range(0, goZones.Length);
        goZones[i].SetActive(true);

        iDamageMultiplyer += 2;

        GameObject[] goNewGO = new GameObject[goZones.Length - 1];


        for (int j = 0; j < goZones.Length - 1; j++)
        {
            if (j < i)
            {
                goNewGO[j] = goZones[j];
            }
            else
            {
                goNewGO[j] = goZones[j + 1];
            }
        }

        goZones = goNewGO;
    }
}
