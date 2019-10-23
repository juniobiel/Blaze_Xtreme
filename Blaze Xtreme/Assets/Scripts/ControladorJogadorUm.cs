using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Personagem;

public class ControladorJogadorUm : MonoBehaviour
{
    public Movimentacao sMovimentacao;
    public GameObject personagem;
    public Animator animacaoJogador;
    public Rigidbody2D controladorJogador;
    
    public float x;
    public float y;
    public bool atack = false;
    public Transform hitBox;
    public GameObject hitBoxPrefab;
    float vida;
    
    
    void Start()
    {
        sMovimentacao = new Movimentacao(personagem, animacaoJogador, controladorJogador);
        //Define o jogador Parado
        sMovimentacao.animacaoJogador.SetBool("esta-Parado", true);

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("HORIZONTAL0");
        y = Input.GetAxis("VERTICAL0");
        if (atack == false)
        {
            sMovimentacao.EstaParado(x, y);
            sMovimentacao.AndarPraBaixo(x, y);
            sMovimentacao.AndarPraCima(x, y);
            sMovimentacao.AndarPraEsquerda(x, y);
            sMovimentacao.AndarPraDireita(x, y);
        }
			
        if (Input.GetButtonDown("AZUL0") && atack == false)
        {
            atack = true;
            controladorJogador.velocity = new Vector2(0, 0);
            animacaoJogador.SetTrigger("habilidade-Um");
        }

    }

    public void OnHitBox()
    {
        GameObject hit = Instantiate(hitBoxPrefab, hitBox.position, hitBox.localRotation);
        Destroy(hit.gameObject, 0.05f);
    }

    public void NoFimDoAtaque()
    {
        atack = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
        case "inimigo":
            if (!animacaoJogador.GetBool("toma-Hit"))
            {
                atack = false;
                animacaoJogador.SetTrigger("toma-Hit");
            }
        break;

        case "vida":

        break;
        }
    }
}
