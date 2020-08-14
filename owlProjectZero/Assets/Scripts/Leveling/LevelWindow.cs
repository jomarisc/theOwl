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
        //SetExperienceBarSize(0.5f);
        //SetLevelNumber(7);
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
        this.levelSystem = levelSystem;

        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
    }
}
