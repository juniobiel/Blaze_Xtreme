using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private int pontosJogadorUm;
    private int pontosJogadorDois;
    void Start()
    {
        pontosJogadorUm = HUDScript.pontosJogadorUm;
        pontosJogadorDois = HUDScript.pontosJogadorDois;

        if (pontosJogadorUm > pontosJogadorDois)
            Debug.Log("Jogador Um ganhou com: " + pontosJogadorUm);
        else if (pontosJogadorDois > pontosJogadorUm)
            Debug.Log("Jogador Um ganhou com: " + pontosJogadorUm);
        else
            Debug.Log("Empatou!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
