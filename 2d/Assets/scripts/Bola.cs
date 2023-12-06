using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bola : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public int velocidade = 5;
    public Vector2 direcao;
    public Vector2 velocidadeJogador;
    
    void Start()
    {
        TryGetComponent(out rb);
        direcao = Random.insideUnitCircle.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direcao = Vector2.Reflect(direcao, collision.contacts[0].normal);
        if (collision.gameObject.CompareTag("Bloquinho"))
        {
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        rb.velocity = direcao.normalized * velocidade;
    }
}
