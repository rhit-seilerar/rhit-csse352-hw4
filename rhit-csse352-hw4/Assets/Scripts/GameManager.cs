using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    float money;
    int obsidian;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public float GetMoney() => money;
    public int GetObsidian() => obsidian;
}
