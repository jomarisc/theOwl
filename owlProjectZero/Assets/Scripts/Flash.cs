using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Flash : MonoBehaviour
{
    public Image img;
    public GameObject theButton;

    private float timer;
    private Vector4 colortest;
    
   
    private void Start()
    {
        //img = GetComponent<Image>();
        colortest = img.color;
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5)
        {
            colortest = new Vector4(0f, 0f, 0f, 0f);
            img.color = colortest;
        }
        if (timer >= 1)
        {
            colortest = new Vector4(255f, 255f, 255f, 255f);
            img.color = colortest;
            timer = 0;
        }
    }

    public void SelectButton()
    {
        EventSystem.current.SetSelectedGameObject(theButton);
    }
}
