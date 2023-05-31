using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardManager : MonoBehaviour
{
    [Header("Misc")]
    [SerializeField] GameObject[] goButtons;

    private GameObject[] goPlayers;
    void Start()
    {
        
    }

    
    void Update()
    {
        goPlayers = GameObject.FindGameObjectsWithTag("Player");

        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < goPlayers.Length - 1; i++)
            {
                if (goPlayers[i + 1].GetComponent<PlayerInfo>().iPlayerKills > goPlayers[i].GetComponent<PlayerInfo>().iPlayerKills)
                {
                    Switch(i + 1, i);
                    i = 0;
                }
            }
        }

        for (int i = 0; i < goButtons.Length; i++)
        {
            if (goPlayers.Length > i)
            {
                goButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = goPlayers[i].GetComponent<PlayerInfo>().iPlayerKills.ToString() + " - " + goPlayers[i].GetComponent<PlayerInfo>().sName;
                goButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().color = goPlayers[i].GetComponent<PlayerInfo>().cColor;
                goButtons[i].GetComponent<SetNewTarget>().goTarget = goPlayers[i];
            }
        }

        //Test

        for(int i = goButtons.Length - 1; i > 0; i--)
        {
            if(goButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text == goButtons[i - 1].transform.GetChild(0).GetComponent<TMP_Text>().text)
            {
                goButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = "";
                goButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().color = Color.gray;
            }
        }

        //Test
    }

    private void Switch(int i, int j)
    {
        GameObject go = goPlayers[i];
        goPlayers[i] = goPlayers[j];
        goPlayers[j] = go;
    }
}
