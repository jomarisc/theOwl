using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsHealthVisual : MonoBehaviour
{

    [SerializeField] private Sprite heart0Sprite;
    [SerializeField] private Sprite heart1Sprite;
    [SerializeField] private Sprite heart2Sprite;
    [SerializeField] private Sprite heart3Sprite;
    [SerializeField] private Sprite heart4Sprite;

    private List<HeartImage> heartImageList;

    private void Awake() 
    {
        heartImageList = new List<HeartImage>();
    }

    private void Start() 
    {

        CreateHeartImage(new Vector2(0, 0)).SetHeartFragments(4);
        CreateHeartImage(new Vector2(30, 0)).SetHeartFragments(1);
        CreateHeartImage(new Vector2(60, 0)).SetHeartFragments(0);

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

        private Image heartImage;
        private HeartsHealthVisual heartsHealthVisual;

        public HeartImage(HeartsHealthVisual heartsHealthVisual, Image heartImage) 
        {
            this.heartsHealthVisual =  heartsHealthVisual;
            this.heartImage = heartImage;
        }

        public void SetHeartFragments(int fragments)
        {
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
    }
}
