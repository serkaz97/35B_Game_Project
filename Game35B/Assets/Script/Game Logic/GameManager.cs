using System.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityHelpers;

public class GameManager : MonoSingleton<GameManager>
{

    private GameLogicManager _logic;


    void Start()
    {
        _logic = GetComponent<GameLogicManager>();
        
    }

}
