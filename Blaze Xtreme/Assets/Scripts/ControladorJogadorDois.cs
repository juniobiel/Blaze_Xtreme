using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Personagem;

public class ControladorJogadorDois : MonoBehaviour
{
    private Personagem personagemJogadorDois;
    private Movimentacao sptMovimentacaoPersonagemDois;
    public GameObject prefabPersonagemDois;
    float contTimerEnergia;
    public float x;
    public float y;
    
    
    void Start()
    {
        prefabPersonagemDois = Instantiate(prefabPersonagemDois, new Vector2(0, 0), Quaternion.identity);
        personagemJogadorDois = prefabPersonagemDois.GetComponent<Personagem>();
        personagemJogadorDois.InstanciarPersonagem("Hosigake");
        sptMovimentacaoPersonagemDois = new Movimentacao(personagemJogadorDois);
        sptMovimentacaoPersonagemDois.SetFlModuloVelocidade(2.0f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().AdicionarPlayers(personagemJogadorDois.transform);

        //Define o jogador Parado
        sptMovimentacaoPersonagemDois.EstaParado(x, y);
        Debug.Log(personagemJogadorDois.GetStrNome());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        contTimerEnergia += Time.deltaTime;
        
        if(contTimerEnergia >= 6.0f)
        {
            personagemJogadorDois.RecarregaEnergia();
            contTimerEnergia -= contTimerEnergia;
        }

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

        if (Input.GetButtonDown("AZUL0") && !personagemJogadorDois.GetBlAttack())
        {
            personagemJogadorDois.SetBlAttack(true);
            personagemJogadorDois.GetRGBDControladorJogador().velocity = new Vector2(0, 0);
            personagemJogadorDois.GetAnimatorPersonagem().SetTrigger("habilidade-Um");
        }

        personagemJogadorDois.GetBarraHP();
    }

    
}
