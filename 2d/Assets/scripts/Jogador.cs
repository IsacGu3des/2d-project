using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public int velocidade = 5;
    private Vector2 direcao;
    void Start()
    {
        
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        direcao = new Vector2(x, 0);
    }

    void FixedUpdate()
    {
        rb.velocity = direcao.normalized * velocidade;
    }
}
