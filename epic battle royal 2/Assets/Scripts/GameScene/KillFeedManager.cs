using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillFeedManager : MonoBehaviour
{
    [Header("Misc")]
    [SerializeField] int iAmount;
    [SerializeField] float fWait;

    public string[] sKillMsgs;
    private Color[] cColors;

    //Debug
    int i = 0;

    void Start()
    {
        sKillMsgs = new string[iAmount];
        cColors = new Color[iAmount];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sKillMsgs.Length; i++)
        {
            transform.GetChild(i).GetComponent<TMP_Text>().text = sKillMsgs[i];
            transform.GetChild(i).GetComponent<TMP_Text>().color = cColors[i];
        }
    }

    public void DebugKillFeed()
    {
        AddKillFedd("Test" + i, "Test" + i, Color.red);
        i++;
    }

    public void AddKillFedd(string s1, string s2, Color c)
    {
        for (int i = sKillMsgs.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                sKillMsgs[0] = s1 + " --> " + s2;
                cColors[0] = c;
            }
            else
            {
                sKillMsgs[i] = sKillMsgs[i - 1];
                cColors[i] = cColors[i - 1];
            }
        }

        StartCoroutine(RemoveKillFeed(sKillMsgs[0], fWait));
    }

    private IEnumerator RemoveKillFeed(string s, float fWait)
    {
        yield return new WaitForSeconds(fWait);

        for (int i = 0; i < sKillMsgs.Length; i++)
        {
            if (sKillMsgs[i] == s)
            {
                sKillMsgs[i] = "";
            }
        }
    }
}
