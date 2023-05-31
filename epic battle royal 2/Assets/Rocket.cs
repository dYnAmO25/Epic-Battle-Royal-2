using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Rocket")]
    [SerializeField] float fRotationSpeed;
    [SerializeField] float fMoveSpeed;
    [SerializeField] GameObject goExplosion;
    
    public GameObject goPlayer;

    private GameObject goTarget;
    private Quaternion qLookRotation;
    private Vector3 v3Direction;

    void Start()
    {
        GameObject[] goPlayers = GameObject.FindGameObjectsWithTag("Player");

        goTarget = goPlayers[Random.Range(0, goPlayers.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (goTarget == null)
        {
            GameObject[] goPlayers = GameObject.FindGameObjectsWithTag("Player");

            goTarget = goPlayers[Random.Range(0, goPlayers.Length)];
        }
        
        //Rotation
        v3Direction = (goTarget.transform.position - transform.position).normalized;

        qLookRotation = Quaternion.LookRotation(v3Direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, qLookRotation, Time.deltaTime * fRotationSpeed);
        //

        transform.position = Vector3.MoveTowards(transform.position, goTarget.transform.position, Time.deltaTime * fMoveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = Instantiate(goExplosion, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
        go.GetComponent<Explosion>().goPlayer = goPlayer;
        Destroy(gameObject);
    }
}
