using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Personagem;

public class ControladorJogadorUm : MonoBehaviour
{
    public GameObject personagem;
    public Animator animacaoJogador;
    public Rigidbody2D controladorJogador;
    public Movimentacao movimentacao;
    public float x;
    public float y;
    private bool atack = false;
    public Transform hitBox;
    public GameObject hitBoxPrefab;
	public int vida = 100;
	public int pontos = 0;

    
    
    void Start()
    {
        movimentacao = new Movimentacao(personagem, animacaoJogador, controladorJogador);
        //Define o jogador Parado
        movimentacao.animacaoJogador.SetBool("esta-Parado", true);

      


    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("HORIZONTAL0");
        y = Input.GetAxis("VERTICAL0");
        if (atack == false)
        {
            movimentacao.EstaParado(x, y);
            movimentacao.AndarPraBaixo(x, y);
            movimentacao.AndarPraCima(x, y);
            movimentacao.AndarPraEsquerda(x, y);
            movimentacao.AndarPraDireita(x, y);
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
       Destroy(hit.gameObject, 0.03f);
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
            animacaoJogador.SetTrigger("toma-Hit");
			vida -= 20;
        break;

        case "vida":

        break;
        }
    }
}
