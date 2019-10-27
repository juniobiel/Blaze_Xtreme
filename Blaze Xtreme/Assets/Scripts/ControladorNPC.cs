using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNPC : MonoBehaviour
{
    public GameObject prefabZumbi;
    float contTimer = 0;
    void Update()
    {
         contTimer += Time.deltaTime;
        if (contTimer >= 6.0f)
         {
            //Spawna Zumbi
            Instantiate(prefabZumbi, new Vector2(5, -5), Quaternion.identity);
            contTimer -= contTimer;
         }
    }

}
