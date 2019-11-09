using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour
{
    float baseHP;
    Image baseBarraHP;
    void Start()
    {
        baseBarraHP = gameObject.GetComponentsInChildren<Image>()[1];
        baseHP = 1;
    }

    // Update is called once per frame
    void Update()
    {
        baseBarraHP.fillAmount = baseHP;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            baseHP -= 0.04f;
            baseBarraHP.fillAmount = baseHP;
        }
            
    }
}
