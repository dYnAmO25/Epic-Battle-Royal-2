using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] GameObject goName;
    [SerializeField] GameObject goHealthbar;
    [SerializeField] GameObject goKillCounter;

    private PlayerInfo PPlayerInfo;

    void Start()
    {
        PPlayerInfo = GetComponent<PlayerInfo>();

        goName.GetComponent<TMP_Text>().text = PPlayerInfo.sName;
        goName.GetComponent<TMP_Text>().color = PPlayerInfo.cColor;

        GetComponent<MeshRenderer>().material = PPlayerInfo.mMat;
    }

    // Update is called once per frame
    void Update()
    {
        goHealthbar.GetComponent<Image>().fillAmount = PPlayerInfo.fPlayerHP / 100;
        goKillCounter.GetComponent<TMP_Text>().text = PPlayerInfo.iPlayerKills.ToString() + " Kills";
    }
}
