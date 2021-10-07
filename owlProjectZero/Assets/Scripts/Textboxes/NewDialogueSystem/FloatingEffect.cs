using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FloatingEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject target = null;
    [SerializeField] float floatingRange= 20f;
    [SerializeField] float waitTime = 1.2f;
    private IEnumerator floatCoroutine;
    float startingY;

    public void Awake(){
        //love.SetActive(false);
        startingY = target.transform.position.y;
        //floatCoroutine = FloatImage();
        
    }

    IEnumerator FloatImage(){
        target.transform.DOMoveY(startingY+floatingRange, 1f);
        yield return new WaitForSeconds(waitTime);
        target.transform.DOMoveY(startingY-floatingRange, 1f);
        yield return new WaitForSeconds(waitTime);
        yield return StartCoroutine(FloatImage());
    }

    void OnEnable(){
        floatCoroutine = FloatImage();
        StartCoroutine(floatCoroutine);
    }

    void OnDisable(){
        
        StopCoroutine(floatCoroutine);
        DOTween.Kill(target.transform, true);
        target.transform.DOMoveY(startingY, 0f);
        //love.transform.position = new Vector2(love.transform.position.x, startingY);
    }
    

}
