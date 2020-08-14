using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    private int level;
    private int experience;
    private int experienceNeededForLevelUp;

    public LevelSystem()
    {
        level = 0;
        experience = 0;
        experienceNeededForLevelUp = 100;
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        
        if(experience >= experienceNeededForLevelUp)
        {
            // Enough experience has been reached for new level
            level++;
            experience -= experienceNeededForLevelUp;
        }
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExperienceNormalized()
    {
        return (float)experience / experienceNeededForLevelUp;
    }

}
