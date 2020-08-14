using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    private Text levelText;
    private Image experienceBarImage;
    private LevelSystem levelSystem;

    private void Awake()
    {
        levelText = transform.Find("LevelText").GetComponent<Text>();
        experienceBarImage = transform.Find("ExperienceBar_BG").Find("ExperienceBar_FG").GetComponent<Image>();
        //SetExperienceBarSize(0.0f);
        //SetLevelNumber(0);
    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        
        experienceBarImage.fillAmount = experienceNormalized;
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = " " + (levelNumber + 1);
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        // Sets the level system 
        // (i.e. sets the level number and experience bar size when a new one is created in a test file)
        this.levelSystem = levelSystem;

        // Update the starting values
        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());

        // Subscribe to the changed events
        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        // Level changed, update text
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        // Experience changed, update bar size
        SetLevelNumber(levelSystem.GetLevelNumber());
    }
}
