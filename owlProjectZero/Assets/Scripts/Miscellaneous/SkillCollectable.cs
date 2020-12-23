using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCollectable : Collectable
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<playerControl>() != null)
        {
            playerScript.AddCurrency(20);
            if(currencyText != null)
                currencyText.text = "Currency: " + playerScript.GetCurrency();
            //gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
