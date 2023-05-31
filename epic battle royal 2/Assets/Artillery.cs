using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artillery : MonoBehaviour
{
    [Header("Misc")]
    [SerializeField] GameObject[] goEffects;
    [SerializeField] float fTime;
    [SerializeField] Color cColor;

    [Header("Explosion")]
    [SerializeField] float fRange;
    [SerializeField] float fMaxDamage;

    void Start()
    {
        Invoke("StartExplosion", fTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartExplosion()
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
                f = fMaxDamage * f; //acCurve.Evaluate(f);
                cInRange[i].GetComponent<CombatManager>().GetAttacked(f);

                if (cInRange[i].GetComponent<CombatManager>().CheckDead())
                {
                    cInRange[i].GetComponent<CombatManager>().KillPlayer("Artillery", cColor);
                }
            }
        }
    }
}
