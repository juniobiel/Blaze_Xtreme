using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Personagem : MonoBehaviour
{
    abstract public Animator GetAnimatorPersonagem();
    abstract public Rigidbody2D GetRGBDControladorJogador();
}
