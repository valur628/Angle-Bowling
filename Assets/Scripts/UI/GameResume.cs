using UnityEngine;
using System.Collections;

public class GameResume : MonoBehaviour
{

    public bool paused;
    
	void Start ()
    {
        paused = false;
	}
	
	void Update ()
    {
            paused = !paused;
        if (paused)
        {
            GameMainManager.GamePulse = true;
        }
        else if (!paused)
        {
            GameMainManager.GamePulse = true;
        }
    }
}﻿