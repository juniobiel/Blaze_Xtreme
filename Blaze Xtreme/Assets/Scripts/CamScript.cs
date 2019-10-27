using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public Transform posicaoPersonagem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posicaoPersonagem = GameObject.FindGameObjectWithTag("Taeda").transform;
        gameObject.transform.position = posicaoPersonagem.position;    
    }
}
