using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeamStatusManager : MonoBehaviour
{
    private GameObject[] goArray;
    private Array aArray;

    private GameObject[] goTextFields;
    private GameObject goSpawnManager;

    private int[] iPlayers;
    private GameObject[] goPlayers;


    void Start()
    {
        goSpawnManager = GameObject.FindGameObjectWithTag("SpawnManager");
        
        goArray = GameObject.FindGameObjectsWithTag("Array");

        if (goArray.Length == 0)
        {
            Debug.Log("Dev Massage: Pls start the game from Mainscreen");
        }
        else
        {
            aArray = goArray[0].GetComponent<Array>();
        }

        if (aArray != null)
        {
            //Enables TextFields
            for (int i = 0; i < aArray.iCurrentPlayers; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }

            goTextFields = GameObject.FindGameObjectsWithTag("TeamText");

            for (int i = 0; i < goTextFields.Length; i++)
            {
                goTextFields[i].GetComponent<TMP_Text>().color = goSpawnManager.GetComponent<SpawnPlayer>().cColors[i];
            }

            iPlayers = new int[goTextFields.Length];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (aArray != null)
        {
            goPlayers = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < iPlayers.Length; i++)
            {
                iPlayers[i] = 0;
            }

            for (int i = 0; i < goPlayers.Length; i++)
            {
                iPlayers[goPlayers[i].GetComponent<PlayerInfo>().iPlayerTeamID]++;
            }

            for (int i = 0; i < goTextFields.Length; i++)
            {
                goTextFields[i].GetComponent<TMP_Text>().text = iPlayers[i].ToString() + " - " + aArray.saNames[i];
                
                if (iPlayers[i] == 0)
                {
                    goTextFields[i].GetComponent<TMP_Text>().fontStyle = FontStyles.Strikethrough;
                    goTextFields[i].GetComponent<DeadHandler>().bDead = true;
                }
            }

            
        }
    }
}
