using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] GameObject goDeath;
    [SerializeField] GameObject goDamage;

    [Header("Stats")]
    public int iMinDamage;
    public int iMaxDamage;
    [SerializeField] int iCooldown;
    [SerializeField] int iRange;
    [SerializeField] int iHealthReward;

    [Header("Misc")]
    [SerializeField] GameObject goRayOrigin;

    private GameObject goKillFeed;

    private float fTime;

    private Animation aAnimation;
    
    private PlayerInfo PPlayerInfo;

    void Start()
    {
        aAnimation = GetComponent<Animation>();
        PPlayerInfo = GetComponent<PlayerInfo>();
        goKillFeed = GameObject.FindGameObjectWithTag("KillFeedManager");
    }

    // Update is called once per frame
    void Update()
    {
        fTime += Time.deltaTime;
        
        if (fTime > iCooldown)
        {
            RaycastHit hit;

            Physics.Raycast(goRayOrigin.transform.position, Vector3.forward, out hit, iRange);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    if (hit.collider.gameObject.GetComponent<PlayerInfo>().iPlayerTeamID != PPlayerInfo.iPlayerTeamID)
                    {
                        fTime = 0;

                        Attack(hit);
                    }
                }
            }
        }
    }

    //Get Attacked
    public void GetAttacked(float f)
    {
        Instantiate(goDamage, transform.position, Quaternion.identity);

        PPlayerInfo.fPlayerHP -= f;
    }

    public void GetAttackedZone(float f)
    {
        PPlayerInfo.fPlayerHP -= f;
    }

    //Attack someone
    private void Attack(RaycastHit hit)
    {
        aAnimation.Play();

        int i = Random.Range(iMinDamage, iMaxDamage + 1);

        hit.collider.gameObject.GetComponent<CombatManager>().GetAttacked(i);

        if (hit.collider.gameObject.GetComponent<CombatManager>().CheckDead())
        {
            hit.collider.gameObject.GetComponent<CombatManager>().KillPlayer(PPlayerInfo.sName, PPlayerInfo.cColor);
            PPlayerInfo.iPlayerKills++;
            PPlayerInfo.fPlayerHP += iHealthReward;
            if (PPlayerInfo.fPlayerHP > 100)
            {
                PPlayerInfo.fPlayerHP = 100;
            }
        }
    }

    //Get Killed
    public void KillPlayer(string sKiller, Color c)
    {
        Instantiate(goDeath, transform.position, Quaternion.identity);

        goKillFeed.GetComponent<KillFeedManager>().AddKillFedd(sKiller, PPlayerInfo.sName, c);

        Destroy(gameObject);
    }

    //Check for Dead
    public bool CheckDead()
    {
        if (PPlayerInfo.fPlayerHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
