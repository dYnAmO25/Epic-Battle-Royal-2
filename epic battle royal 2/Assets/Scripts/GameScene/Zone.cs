using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [Header("Misc")]
    [SerializeField] Color cColor;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<ZoneChecker>().bInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<ZoneChecker>().bInZone = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CombatManager>().GetAttackedZone(Time.deltaTime * transform.parent.GetComponent<ZoneManager>().iDamageMultiplyer);

            if (other.GetComponent<CombatManager>().CheckDead())
            {
                other.GetComponent<CombatManager>().KillPlayer("Zone", cColor);
            }
        }
    }
}
