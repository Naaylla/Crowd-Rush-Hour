using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    public GameObject[] Levels;
    
    int CurrentLevel;

    public void correctAnswer()
    {
        if(CurrentLevel + 1 != Levels.Length) 
        {
            Levels[CurrentLevel].SetActive(false);
            CurrentLevel++;
            Levels[CurrentLevel].SetActive(true);
        }

    }
}
