using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Misc")]
    [SerializeField] GameObject[] goEffects;

    public GameObject goPlayer;

    [Header("Explosion")]
    [SerializeField] float fRange;
    [SerializeField] float fMaxDamage;

    void Start()
    {
        for (int i = 0; i < goEffects.Length; i++)
        {
            goEffects[i].SetActive(true);
            goEffects[i].GetComponent<ParticleSystem>().Play();
        }

        Collider[] cInRange = Physics.OverlapSphere(transform.position, fRange);

        for (int i = 0; i < cInRange.Length; i++)
        {
            if (cInRange[i].tag == "Player")
            {
                float f = Vector3.Distance(cInRange[i].transform.position, transform.position / fRange);
                f = fMaxDamage * f;

                if (cInRange[i].gameObject != goPlayer)
                {
                    cInRange[i].GetComponent<CombatManager>().GetAttacked(f);
                }

                if (cInRange[i].GetComponent<CombatManager>().CheckDead())
                {
                    if (goPlayer != null)
                    {
                        cInRange[i].GetComponent<CombatManager>().KillPlayer(goPlayer.GetComponent<PlayerInfo>().sName + " [ROCKET]", goPlayer.GetComponent<PlayerInfo>().cColor);
                        goPlayer.GetComponent<PlayerInfo>().iPlayerKills++;
                    }
                    else
                    {
                        cInRange[i].GetComponent<CombatManager>().KillPlayer("ROCKET", Color.red);
                    }
                }
            }
        }
    }
}
