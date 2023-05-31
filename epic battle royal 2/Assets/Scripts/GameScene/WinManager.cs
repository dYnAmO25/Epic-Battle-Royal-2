using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinManager : MonoBehaviour
{
    [Header("Misc")]
    [SerializeField] GameObject goWinScreen;
    
    private TeamStatusManager PTeamStatusManager;
    private GameObject[] goTexts;
    private Array PArray;

    private int k;

    void Start()
    {
        PTeamStatusManager = GameObject.FindGameObjectWithTag("TeamManager").GetComponent<TeamStatusManager>();
        PArray = GameObject.FindGameObjectWithTag("Array").GetComponent<Array>();
    }

    // Update is called once per frame
    void Update()
    {
        goTexts = GameObject.FindGameObjectsWithTag("TeamText");


        k = 0;

        for (int i = 0; i < goTexts.Length; i++)
        {
            if (goTexts[i].GetComponent<DeadHandler>().bDead != true)
            {
                k++;
            }
        }

        if (k == 1)
        {
            goWinScreen.SetActive(true);
            int i = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().iPlayerTeamID;
            goWinScreen.GetComponent<TMP_Text>().text = "Team " + PArray.saNames[i] + " won!";
            goWinScreen.GetComponent<TMP_Text>().color = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>().cColor;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
