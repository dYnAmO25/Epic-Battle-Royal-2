using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerAmount : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject goInputField;
    [SerializeField] GameObject goButton;
    [SerializeField] GameObject goSpawnButtonText;
    [SerializeField] GameObject goTeamAmount;
    [SerializeField] GameObject goAmountText;

    [Header("Saved")]
    [SerializeField] GameObject goSavedArray;
     
    private int iPlayerPerTeam;

    void Update()
    {
        int.TryParse(goInputField.GetComponent<TMP_InputField>().text, out iPlayerPerTeam);

        goAmountText.GetComponent<TMP_Text>().text = (iPlayerPerTeam * goTeamAmount.GetComponent<TeamAmount>().iCurrentPlayer).ToString() + "/5 Bots";

        if (iPlayerPerTeam * goTeamAmount.GetComponent<TeamAmount>().iCurrentPlayer >= 5)
        {
            goButton.SetActive(true);
            
            iPlayerPerTeam *= goTeamAmount.GetComponent<TeamAmount>().iCurrentPlayer;

            goSavedArray.GetComponent<Array>().iPlayers = iPlayerPerTeam;

            //goSpawnButtonText.GetComponent<TMP_Text>().text = "Spawn " + iPlayerPerTeam + " Bots";
        }
        else
        {
            goButton.SetActive(false);
        }
    }

    public void LoadNextGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
