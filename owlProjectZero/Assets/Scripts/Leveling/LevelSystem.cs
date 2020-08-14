using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

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
        
        while(experience >= experienceNeededForLevelUp)
        {
            // Enough experience has been reached for new level
            level++;
            experience -= experienceNeededForLevelUp;

            // Fire event when level changes
            if (OnLevelChanged != null)
            {
                OnLevelChanged(this, EventArgs.Empty);
            }
        }
        // Fire event when experience changes
        if(OnExperienceChanged != null)
        {
            OnExperienceChanged(this, EventArgs.Empty);
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
