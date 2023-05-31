using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryManager : MonoBehaviour
{
    [Header("Misc")]
    [SerializeField] int iMin;
    [SerializeField] int iMax;
    [SerializeField] float fSize;
    [SerializeField] float fWaitTime;
    [SerializeField] float fMinTime;
    [SerializeField] float fMaxTime;
    [SerializeField] GameObject goArtillery;

    [Header("UI")]
    [SerializeField] float fFlashingTime;
    [SerializeField] GameObject goUI;

    private int iShots;
    private int iShootedShots;
    private float fTimeGone;

    private float fT1;
    private float fT2;
    private float fT3;

    private float fTimeGoneFlash;
    private bool bFlash = true;

    void Start()
    {
        iShots = Random.Range(iMin, iMax);
    }

    // Update is called once per frame
    void Update()
    {
        fTimeGone += Time.deltaTime;

        if (fTimeGone > fWaitTime - 5)
        {
            //Flashing UI Element
            if (bFlash)
            {
                fTimeGoneFlash += Time.deltaTime;
                if (fTimeGoneFlash >= fFlashingTime)
                {
                    goUI.SetActive(!goUI.activeSelf);
                    fTimeGoneFlash = 0;
                }
            }

            if (fTimeGone > fWaitTime)
            {
                if (iShootedShots < iShots)
                {
                    //fT1 = Random.Range(fMinTime, fMaxTime);
                    if (fT2 >= fT1)
                    {
                        fT1 = Random.Range(fMinTime, fMaxTime);
                        Invoke("ShotArtillery", fT1);
                        fT2 = 0;
                    }
                    fT2 += Time.deltaTime;
                }
                else
                {
                    bFlash = false;
                    goUI.SetActive(false);
                }
            }
        }
    }

    private void ShotArtillery()
    {
        Vector3 v3 = new Vector3(Random.Range(-fSize, fSize), 0, Random.Range(-fSize, fSize));
        Instantiate(goArtillery, v3, Quaternion.identity);
        iShootedShots++;
    }
}
