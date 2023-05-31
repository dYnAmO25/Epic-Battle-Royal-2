using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    [Header("Player Stuff")]
    [SerializeField] GameObject goPlayer;
    public Material[] mMats;
    public Color[] cColors;
    
    private GameObject[] goArray;
    private Array aArray;

    void Awake()
    {
        goArray = GameObject.FindGameObjectsWithTag("Array");

        if (goArray.Length == 0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            aArray = goArray[0].GetComponent<Array>();
        }

        if (aArray != null)
        {
            for (int i = 0; i < aArray.iPlayers; i++)
            {
                //Spawns Player
                GameObject goP = Instantiate(goPlayer, new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)), Quaternion.identity);
                //Sets Player ID
                goP.GetComponent<PlayerInfo>().iPlayerID = i;
                //Set Team ID
                goP.GetComponent<PlayerInfo>().iPlayerTeamID = i % aArray.saNames.Length;
                //Sets Player HP
                goP.GetComponent<PlayerInfo>().fPlayerHP = 100;
                //Sets Player Name
                goP.GetComponent<PlayerInfo>().sName = "[" + i + "] " + aArray.saNames[i % aArray.saNames.Length];
                //Sets Player Material
                goP.GetComponent<PlayerInfo>().mMat = mMats[i % aArray.saNames.Length];
                //Sets Player Color
                goP.GetComponent<PlayerInfo>().cColor = cColors[i % aArray.saNames.Length];
            }
        }
    }
}
