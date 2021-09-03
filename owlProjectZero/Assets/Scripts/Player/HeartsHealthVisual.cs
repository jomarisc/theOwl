using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;
using CodeMonkey.Utils;

public class HeartsHealthVisual : MonoBehaviour
{

    [SerializeField] private Sprite heart0Sprite;
    [SerializeField] private Sprite heart1Sprite;
    [SerializeField] private Sprite heart2Sprite;
    [SerializeField] private Sprite heart3Sprite;
    [SerializeField] private Sprite heart4Sprite;

    private List<HeartImage> heartImageList;
    private HeartsHealthSystem heartsHealthSystem;

    private void Awake() 
    {
        heartImageList = new List<HeartImage>();
    }

    private void Start() 
    {
        FunctionPeriodic.Create(HealingAnimatedPeriodic, 0.5f);
        HeartsHealthSystem heartsHealthSystem = new HeartsHealthSystem(4);
        SetHeartsHealthSystem(heartsHealthSystem);
    }

    public void TestDamage1()
    {
        heartsHealthSystem.Damage(1);
    }

    public void TestDamage4()
    {
        heartsHealthSystem.Damage(4);
    }

    public void TestHeal1()
    {
        heartsHealthSystem.Heal(1);
    }

    public void TestHeal4()
    {
        heartsHealthSystem.Heal(4);
    }

    public void SetHeartsHealthSystem(HeartsHealthSystem heartsHealthSystem)
    {
        this.heartsHealthSystem = heartsHealthSystem;

        List<HeartsHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        Vector2 heartAnchoredPosition = new Vector2(0, 0);

        // New way of creating heart images
        for(int i = 0; i < heartList.Count; i++)
        {
        
            HeartsHealthSystem.Heart heart = heartList[i];
            CreateHeartImage(heartAnchoredPosition).SetHeartFragments(heart.GetFragmentAmount());
            heartAnchoredPosition += new Vector2(30, 0);
        }

        // Firing off function when this event occurs in HeartsHealthSystem
        heartsHealthSystem.OnDamaged += HeartsHealthSystem_OnDamaged;
        heartsHealthSystem.OnHealed += HeartsHealthSystem_OnHealed;
        heartsHealthSystem.OnDead += HeartsHealthSystem_OnDead;

        // Old way of creating heart images
        // CreateHeartImage(new Vector2(0, 0)).SetHeartFragments(4);
        // CreateHeartImage(new Vector2(30, 0)).SetHeartFragments(1);
        // CreateHeartImage(new Vector2(60, 0)).SetHeartFragments(0);

    }
    
    private void HeartsHealthSystem_OnDead(object sender, System.EventArgs e)
    {
        Debug.Log(message:$"<size=16><color=red> Player out of hearts </color></size>");
    }

    private void HeartsHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        // Hearts health system was healed
        //RefreshAllHearts();
    }

    private void HeartsHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        // Hearts health system was damaged
        RefreshAllHearts();
    }

    private void RefreshAllHearts()
    {
        // Iterating through all the hearts and refreshing the hearts
        // Hearts health system was damaged
        List<HeartsHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        for (int i = 0; i < heartImageList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            HeartsHealthSystem.Heart heart = heartList[i];
            heartImage.SetHeartFragments(heart.GetFragmentAmount());
        }
    }

    private void HealingAnimatedPeriodic()
    {
        List<HeartsHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        for (int i = 0; i < heartList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            HeartsHealthSystem.Heart heart = heartList[i];
            if(heartImage.GetFragmentAmount() != heart.GetFragmentAmount())
            {
                // Visual is different from logic
                heartImage.AddHeartVisualFragment();
                break;
            }
        }
    }

    private HeartImage CreateHeartImage(Vector2 anchoredPosition) 
    {
        // Create Game Object
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));
        
        // Set as child of this transform
        heartGameObject.transform.parent = transform;
        heartGameObject.transform.localPosition = Vector3.zero;
        
        // Locate and Size heart
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(10, 10);

        // Set heart sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heart4Sprite;

        HeartImage heartImage = new HeartImage(this, heartImageUI);
        heartImageList.Add(heartImage);

        return heartImage;
    }

    // Represents a single Heart
    public class HeartImage {
        
        public int fragments;
        private Image heartImage;
        private HeartsHealthVisual heartsHealthVisual;

        public HeartImage(HeartsHealthVisual heartsHealthVisual, Image heartImage) 
        {
            this.heartsHealthVisual =  heartsHealthVisual;
            this.heartImage = heartImage;
        }

        public void SetHeartFragments(int fragments)
        {
            this.fragments = fragments;
            switch (fragments)
            {
                case 0:
                    heartImage.sprite = heartsHealthVisual.heart0Sprite;
                    break;
                case 1:
                    heartImage.sprite = heartsHealthVisual.heart1Sprite;
                    break;
                case 2:
                    heartImage.sprite = heartsHealthVisual.heart2Sprite;
                    break;
                case 3:
                    heartImage.sprite = heartsHealthVisual.heart3Sprite;
                    break;
                case 4:
                    heartImage.sprite = heartsHealthVisual.heart4Sprite;
                    break;
            }
        }

        public int GetFragmentAmount()
        {
            return fragments;
        }

        public void AddHeartVisualFragment()
        {
            SetHeartFragments(fragments + 1);
        }
    }
}
