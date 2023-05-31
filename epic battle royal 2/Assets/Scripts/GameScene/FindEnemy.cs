using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{
    public const int iRays = 5;

    private Vector3[] av3Directions;
    private RaycastHit[] hits;
    public GameObject goTargetPlayer;

    [SerializeField] GameObject goRayOrigin;
    [SerializeField] float fDistance;

    void Start()
    {
        av3Directions = new Vector3[iRays];

        hits = new RaycastHit[iRays];
    }

    void Update()
    {
        av3Directions[0] = transform.forward;
        av3Directions[1] = (transform.forward + -transform.right) / 2;
        av3Directions[1].Normalize();
        av3Directions[2] = (transform.forward + transform.right) / 2;
        av3Directions[2].Normalize();
        av3Directions[3] = (av3Directions[0] + av3Directions[1]) / 2;
        av3Directions[3].Normalize();
        av3Directions[4] = (av3Directions[0] + av3Directions[2]) / 2;
        av3Directions[4].Normalize();

        int iHits = 0;

        for (int i = 0; i < iRays; i++)
        {
            Debug.DrawRay(goRayOrigin.transform.position, av3Directions[i], Color.red);
            Physics.Raycast(goRayOrigin.transform.position, av3Directions[i], out hits[i], fDistance);

            if (hits[i].collider != null)
            {
                if (hits[i].collider.tag == "Player")
                {
                    if (hits[i].collider.gameObject.GetComponent<PlayerInfo>().iPlayerTeamID != gameObject.GetComponent<PlayerInfo>().iPlayerTeamID)
                    {
                        goTargetPlayer = hits[i].collider.gameObject;

                        iHits++;
                    }
                }
            }
        }

        if (iHits == 0)
        {
            goTargetPlayer = null;
        }
    }
}
