using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotLogic : MonoBehaviour
{
    private ZoneChecker PZoneChecker;
    private Patrol PPatrol;
    private FindEnemy PFindEnemy;
    private NavMeshAgent navAgent;

    private NavMeshPath path;

    void Start()
    {
        PZoneChecker = GetComponent<ZoneChecker>();
        PPatrol = GetComponent<Patrol>();
        PFindEnemy = GetComponent<FindEnemy>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(GetDestination());
    }

    private Vector3 GetDestination()
    {
        if (PZoneChecker.bInZone)
        {
            PPatrol.v3PatrolPos = Vector3.zero;
            
            return Vector3.zero;
        }
        else
        {
            if (PFindEnemy.goTargetPlayer != null)
            {
                return PFindEnemy.goTargetPlayer.transform.position;
            }
            else
            {
                return PPatrol.v3PatrolPos;
            }
        }
    }
}
