using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour
{
    public string[] saNames;
    public int iPlayers;
    public int iCurrentPlayers;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
