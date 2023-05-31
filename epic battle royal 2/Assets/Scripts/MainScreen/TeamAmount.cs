using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TeamAmount : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] GameObject goMButton;
    [SerializeField] GameObject goPButton;

    [Header("Text")]
    [SerializeField] GameObject goText;

    [Header("Names")]
    [SerializeField] GameObject goNamePlane;
    [SerializeField] GameObject goArray;

    [Header("Logic")]
    [SerializeField] int iMinPlayer;
    [SerializeField] int iMaxPlayer;

    public int iCurrentPlayer;
        

    void Start()
    {
        iCurrentPlayer = iMinPlayer;
    }

    void Update()
    {
        //SetsButtons States
        if (iCurrentPlayer == iMinPlayer)
        {
            goMButton.SetActive(false);
        }
        else
        {
            goMButton.SetActive(true);
        }
        
        
        if (iCurrentPlayer == iMaxPlayer)
        {
            goPButton.SetActive(false);
        }
        else
        {
            goPButton.SetActive(true);
        }

        //Saves Current Player Amount
        goArray.GetComponent<Array>().iCurrentPlayers = iCurrentPlayer;

        //Sets Text
        goText.GetComponent<TMP_Text>().text = iCurrentPlayer.ToString();

        //Create new Array
        goArray.GetComponent<Array>().saNames = new string[iCurrentPlayer];

        //Enabels Input Fields
        for (int i = 0; i < iCurrentPlayer; i++)
        {
            goNamePlane.transform.GetChild(i).gameObject.SetActive(true);

            //Saves Name to array
            goArray.GetComponent<Array>().saNames[i] = goNamePlane.transform.GetChild(i).gameObject.GetComponent<TMP_InputField>().text;
        }
        //Disables Input Fields
        for (int i = 11; i >= iCurrentPlayer; i--)
        {
            goNamePlane.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    public void OnMButtonClick()
    {
        iCurrentPlayer--;
    }

    public void OnPButtonClick()
    {
        iCurrentPlayer++;
    }

}
