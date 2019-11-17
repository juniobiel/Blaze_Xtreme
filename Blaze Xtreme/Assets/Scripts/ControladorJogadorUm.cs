using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Personagem;

public class ControladorJogadorUm : MonoBehaviour
{
    private Taeda personagemJogadorUm;
    private Movimentacao sptMovimentacaoPersonagemUm;
    public GameObject prefabPersonagemUm;
    public float x;
    public float y;
    HUDScript sptPontos;
    
    void Start()
    {
        prefabPersonagemUm = Instantiate(prefabPersonagemUm, new Vector2(0, 0), Quaternion.identity);

        personagemJogadorUm = prefabPersonagemUm.GetComponent<Taeda>();
        personagemJogadorUm.InstanciarPersonagem("Taeda");

        sptMovimentacaoPersonagemUm = gameObject.AddComponent<Movimentacao>();
        sptMovimentacaoPersonagemUm.SetsptPersonagem(personagemJogadorUm);
        sptMovimentacaoPersonagemUm.SetFlModuloVelocidade(2.0f);

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().AdicionarPlayers(personagemJogadorUm.transform);

        sptPontos = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>();
        sptPontos.SetPontosJogadorUm(0);

        //Define o jogador Parado
        sptMovimentacaoPersonagemUm.EstaParado(x, y);
        Debug.Log(personagemJogadorUm.GetStrNome());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        x = Input.GetAxis("HORIZONTAL0");
        y = Input.GetAxis("VERTICAL0");
        if (!personagemJogadorUm.GetBlAttack())
        {
            sptMovimentacaoPersonagemUm.EstaParado(x, y);
            sptMovimentacaoPersonagemUm.AndarPraBaixo(x, y);
            sptMovimentacaoPersonagemUm.AndarPraCima(x, y);
            sptMovimentacaoPersonagemUm.AndarPraEsquerda(x, y);
            sptMovimentacaoPersonagemUm.AndarPraDireita(x, y);
        }

        if (Input.GetButtonDown("AZUL0") && !personagemJogadorUm.GetBlAttack())
        {
            personagemJogadorUm.SetBlAttack(true);
            personagemJogadorUm.GetRGBDControladorJogador().velocity = new Vector2(0, 0);
            personagemJogadorUm.GetAnimatorPersonagem().SetTrigger("habilidade-Um");
        }

        personagemJogadorUm.GetBarraHP();
    }

    
}
