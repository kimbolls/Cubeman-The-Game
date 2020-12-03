using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty_menu : MonoBehaviour
{
    public RandomSpawner RandomSpawner;
    public level_control LevelControl;
    
    public enum DifficultyEnum {Easy,Normal,Hard};
    // public DifficultyEnum Difficulty;
    
    public void SetEasy()
    {
        RandomSpawner.Difficulty = DifficultyEnum.Easy;
        LevelControl.DifficultySet();
    }

    public void SetNormal()
    {
        RandomSpawner.Difficulty = DifficultyEnum.Normal;
        LevelControl.DifficultySet();
    }

    public void SetHard()
    {
        RandomSpawner.Difficulty = DifficultyEnum.Hard;
        LevelControl.DifficultySet();
    }


}
