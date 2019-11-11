using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour
{
    float baseHP;
    Image baseBarraHP;
    float danoZumbiNPC;
    float contTimerCollider;


    void Start()
    {
        contTimerCollider = 0f;
        baseBarraHP = gameObject.GetComponentsInChildren<Image>()[1];
        baseHP = 1;
    }

    // Update is called once per frame
    void Update()
    {
        baseBarraHP.fillAmount = baseHP;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "inimigo":
                if(baseHP != 0)
                {
                    danoZumbiNPC = col.gameObject.GetComponent<ZumbiNPC>().GetFlDano();
                    baseHP -= danoZumbiNPC;
                }
                else if (baseHP <= 0)
                    Debug.Log("Game Over");

                break;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "inimigo":
                contTimerCollider += Time.deltaTime;
                if(contTimerCollider >= 1f)
                {
                    if(baseHP != 0f)
                    {
                        danoZumbiNPC = col.gameObject.GetComponent<ZumbiNPC>().GetFlDano();
                        baseHP -= danoZumbiNPC;
                    }
                    else if(baseHP <= 0f)
                    {
                        //game over
                    }
                    contTimerCollider -= contTimerCollider;
                }
                break;
        }
    }
    // -------------------------- Getters --------------------------
    public Image GetBarraHPBase()
    {
      return baseBarraHP;
    }

    public float GetFillAmount()
    {
      return baseBarraHP.fillAmount;
    }
}
