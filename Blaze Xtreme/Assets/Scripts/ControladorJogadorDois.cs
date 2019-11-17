using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Personagem;

public class ControladorJogadorDois : MonoBehaviour
{
    private Hoshigake personagemJogadorDois;
    private Movimentacao sptMovimentacaoPersonagemDois;
    public GameObject prefabPersonagemDois;
    public float x;
    public float y;
    HUDScript sptPontos;


    void Start()
    {
        prefabPersonagemDois = Instantiate(prefabPersonagemDois, new Vector2(2, 0), Quaternion.identity);
        
        personagemJogadorDois = prefabPersonagemDois.GetComponent<Hoshigake>();
        personagemJogadorDois.InstanciarPersonagem("Hoshigake");

        sptMovimentacaoPersonagemDois = gameObject.AddComponent<Movimentacao>();
        sptMovimentacaoPersonagemDois.SetsptPersonagem(personagemJogadorDois);
        sptMovimentacaoPersonagemDois.SetFlModuloVelocidade(2.0f);

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().AdicionarPlayers(personagemJogadorDois.transform);

        //Define o jogador Parado
        sptMovimentacaoPersonagemDois.EstaParado(x, y);
        Debug.Log(personagemJogadorDois.GetStrNome());

        sptPontos = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>();
        sptPontos.SetPontosJogadorDois(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        x = Input.GetAxis("HORIZONTAL1");
        y = Input.GetAxis("VERTICAL1");
        if (!personagemJogadorDois.GetBlAttack())
        {
            sptMovimentacaoPersonagemDois.EstaParado(x, y);
            sptMovimentacaoPersonagemDois.AndarPraBaixo(x, y);
            sptMovimentacaoPersonagemDois.AndarPraCima(x, y);
            sptMovimentacaoPersonagemDois.AndarPraEsquerda(x, y);
            sptMovimentacaoPersonagemDois.AndarPraDireita(x, y);
        }

        if (Input.GetButtonDown("AZUL1") && !personagemJogadorDois.GetBlAttack())
        {
            personagemJogadorDois.SetBlAttack(true);
            personagemJogadorDois.GetRGBDControladorJogador().velocity = new Vector2(0, 0);
            personagemJogadorDois.GetAnimatorPersonagem().SetTrigger("habilidade-Um");
        }

        personagemJogadorDois.GetBarraHP();
    }

    
}
