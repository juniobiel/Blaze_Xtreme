﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNPC : MonoBehaviour
{
    List<GameObject> listaDeZumbis = new List<GameObject>();
    public GameObject prefabZumbi;
    float contTimer = 0;
    void Update()
    {
         contTimer += Time.deltaTime;
        if (contTimer >= 6.0f)
         {
            //Spawna Zumbi
            float x = Random.Range(-10, 10);
            float y = Random.Range(-10, 10);
            listaDeZumbis.Add(Instantiate(prefabZumbi, new Vector2(x, y), Quaternion.identity));
            contTimer -= contTimer;
         }
    }

    public void atualizarTodosNPCs(float dano, float velocidade)
    {
        foreach (GameObject aux in listaDeZumbis)
        {
            ZumbiNPC refNPC = aux.GetComponent<ZumbiNPC>();

            refNPC.SetFlDano(dano);
            refNPC.SetFlSpeed(velocidade);
        }

    }

}
