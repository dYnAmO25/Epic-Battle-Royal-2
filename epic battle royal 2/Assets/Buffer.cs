using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffer : MonoBehaviour
{
    [Header("Buffs")]
    [SerializeField] int iAddMin;
    [SerializeField] int iAddMax;
    
    private int iOriginalMinD;
    private int iOriginalMaxD;

    void Start()
    {
        iOriginalMinD = GetComponent<CombatManager>().iMinDamage;
        iOriginalMaxD = GetComponent<CombatManager>().iMaxDamage;
    }

    
    void Update()
    {
        GetComponent<CombatManager>().iMinDamage = iOriginalMinD + (iAddMin * GetComponent<PlayerInfo>().iPlayerKills);
        GetComponent<CombatManager>().iMaxDamage = iOriginalMaxD + (iAddMax * GetComponent<PlayerInfo>().iPlayerKills);
    }
}
