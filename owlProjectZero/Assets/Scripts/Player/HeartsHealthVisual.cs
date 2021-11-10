using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;
using CodeMonkey.Utils;

public class HeartsHealthVisual : MonoBehaviour
{
    [Header("Healthbar Images")]
    [SerializeField] private Sprite heart0Sprite;
    [SerializeField] private Sprite heart1Sprite;
    [SerializeField] private Sprite heart2Sprite;
    [SerializeField] private Sprite heart3Sprite;
    [SerializeField] private Sprite heart4Sprite;
    
    [Header("Healthbar Animation")]
    [SerializeField] private AnimationClip heartFullAnimationClip;

    [Header("Healthbar State Management")]
    private List<HeartImage> heartImageList;
    public HeartsHealthSystem heartsHealthSystem; // private
    private bool isHealing;

    [Header("Player")]
    private GameObject playerGameObject;
    private playerControl pc;
    int pcHealth;

    private void Awake() 
    {
        heartImageList = new List<HeartImage>();
    }

    private void Start() 
    {

        // Find player to access the playerControl script within Game Object
        // This is used to trigger certain states within the player
        playerGameObject = GameObject.Find("player"); // So that we don't need to attach the player in each individual scene
        pc = playerGameObject.GetComponent<playerControl>();
        pcHealth = (int) pc.CONSTANTS.MAX_HEALTH;

        // Important note: this is affected by any changes to the Time variable in the game
        // EX: This animation will not show when trying to heal and the Time variable is set to 0f when pressing the Pause button
        FunctionPeriodic.Create(HealingAnimatedPeriodic, 0.05f);
        HeartsHealthSystem heartsHealthSystem = new HeartsHealthSystem(pcHealth / 2); // Test number was 20
        heartsHealthSystem.pc = this.pc;
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

    public HeartsHealthSystem GetHeartsHealthSystem()
    {
        return heartsHealthSystem;
    }

    public void SetHeartsHealthSystem(HeartsHealthSystem heartsHealthSystem)
    {
        this.heartsHealthSystem = heartsHealthSystem;

        List<HeartsHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
        // Singular row
        // Vector2 heartAnchoredPosition = new Vector2(0, 0);

        // Multiple rows
        int row = 0;
        int col = 0;
        int colMax = 10;
        float rowColSize = 20f; // Distance between each column

        // New way of creating heart images
        for(int i = 0; i < heartList.Count; i++)
        {
        
            HeartsHealthSystem.Heart heart = heartList[i];
            // Multiple row support
            Vector2 heartAnchoredPosition = new Vector2(col * rowColSize, -row * rowColSize);
            
            // Original code
            CreateHeartImage(heartAnchoredPosition).SetHeartFragments(heart.GetFragmentAmount());
            
            // Singular row
            //heartAnchoredPosition += new Vector2(20, 0);
            
            // Multiple row support
            col++;
            if (col >= colMax)
            {
                row++;
                col = 0;
            }
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
        pc.GoToDeadState();
    }

    private void HeartsHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        // Hearts health system was healed
        //RefreshAllHearts();
        isHealing = true;
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

        //Debug.Log(message: $"<size=16><color=green> Entered HealingAnimatedPeriodic! </color></size>");
        if (isHealing)
        {
            bool fullyHealed = true;
            List<HeartsHealthSystem.Heart> heartList = heartsHealthSystem.GetHeartList();
            for (int i = 0; i < heartList.Count; i++)
            {
                HeartImage heartImage = heartImageList[i];
                HeartsHealthSystem.Heart heart = heartList[i];

                // Debug.Log(message: $"<size=16><color=orange> Before IF statement Adding Heart Visual Fragment! </color></size>");

                if(heartImage.GetFragmentAmount() != heart.GetFragmentAmount())
                {
                    // Debug.Log(message: $"<size=16><color=orange> Before Adding Heart Visual Fragment! </color></size>");
                    
                    // Visual is different from logic
                    heartImage.AddHeartVisualFragment();
                    if (heartImage.GetFragmentAmount() == HeartsHealthSystem.MAX_FRAGMENT_AMOUNT)
                    {
                        // This heart was fully healed
                        heartImage.PlayHeartRestoredAnimation();
                    }
                    fullyHealed = false;
                    break;
                }
            }
            if (fullyHealed)
            {
                isHealing = false;
            }
        }
    }

    private HeartImage CreateHeartImage(Vector2 anchoredPosition) 
    {
        // Create Game Object
        GameObject heartGameObject = new GameObject("Heart", typeof(Image), typeof(Animation));
        
        // Set as child of this transform
        heartGameObject.transform.parent = transform;
        heartGameObject.transform.localPosition = Vector3.zero;
        
        // Locate and Size heart
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(10, 10);

        heartGameObject.GetComponent<Animation>().AddClip(heartFullAnimationClip, "HeartRestored");

        // Set heart sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heart4Sprite;

        HeartImage heartImage = new HeartImage(this, heartImageUI, heartGameObject.GetComponent<Animation>());
        heartImageList.Add(heartImage);

        return heartImage;
    }

    // Represents a single Heart
    public class HeartImage {
        
        public int fragments;
        private Image heartImage;
        private HeartsHealthVisual heartsHealthVisual;
        private Animation animation;

        public HeartImage(HeartsHealthVisual heartsHealthVisual, Image heartImage, Animation animation) 
        {
            this.heartsHealthVisual =  heartsHealthVisual;
            this.heartImage = heartImage;
            this.animation = animation;
        }

        public void SetHeartFragments(int fragments)
        {

            Debug.Log(message: $"<size=16><color=green> Withing SetHeartFragments! </color></size>");

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
            Debug.Log(message: $"<size=16><color=red> Within Adding Heart Visual Fragment! </color></size>");
            SetHeartFragments(fragments + 1);
        }

        public void PlayHeartRestoredAnimation()
        {
            animation.Play("HeartRestored", PlayMode.StopAll);
        }
    }
}
