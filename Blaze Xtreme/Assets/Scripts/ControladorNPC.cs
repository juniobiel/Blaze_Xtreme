using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNPC : MonoBehaviour
{
    List<GameObject> listaDeZumbis = new List<GameObject>();
    public GameObject prefabZumbi;
    float contTimer = 0;

    float SpeedAtual;
    float DanoAtual;

    void Start()
    {
        SpeedAtual = prefabZumbi.GetComponent<ZumbiNPC>().GetFlSpeed();
        DanoAtual = prefabZumbi.GetComponent<ZumbiNPC>().GetFlDano();
    }
    void Update()
    {
         contTimer += Time.deltaTime;
        if (contTimer >= 6.0f)
         {
            //Spawna Zumbi
            float x = Random.Range(-10, 10);
            float y = Random.Range(-10, 10);
            listaDeZumbis.Add(Instantiate(prefabZumbi, new Vector2(x, y), Quaternion.identity));
            CopiaAtributosZumbi(); //atualizar ao instanciar
            contTimer -= contTimer;
         }
    }

    public void CopiaAtributosZumbi()
    {
        int indexador = listaDeZumbis.Count - 1;
        listaDeZumbis[indexador].GetComponent<ZumbiNPC>().SetFlSpeed(SpeedAtual);
    }

    public void AtualizarTodosNPCs(float dano, float velocidade) //verificar este metodo
    {
        ZumbiNPC scriptAtt = prefabZumbi.GetComponent<ZumbiNPC>();

        dano += scriptAtt.GetFlDano();
        velocidade += scriptAtt.GetFlSpeed();

        scriptAtt.SetFlDano(dano);
        scriptAtt.SetFlSpeed(velocidade);

        SpeedAtual = velocidade;
        DanoAtual = dano;

        foreach (GameObject aux in listaDeZumbis)
        {
            ZumbiNPC refNPC = aux.GetComponent<ZumbiNPC>();

            refNPC.SetFlDano(dano);
            refNPC.SetFlSpeed(velocidade);

            Debug.Log("A velocidade do zumbi agora e: Dentro da lista " + velocidade);
            Debug.Log("O dano do zumbi agora e: Dentro da lista " + dano);

        }
        Debug.Log("A velocidade do zumbi agora e: " + velocidade);
        Debug.Log("O dano do zumbi agora e: " + dano);
    }

    public List<GameObject> GetListaZumbi()
    {
        return this.listaDeZumbis;
    }

}
