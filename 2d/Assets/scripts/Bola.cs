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
        direcao = new Vector2(direcao.x,1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.contacts.Length == 1)
        {
            direcao = Vector2.Reflect(direcao, collision.contacts[0].normal);
        }
        else
        {
            Vector2 normalMedia = Vector2.zero;
            foreach (var ponto in collision.contacts)
            {
                normalMedia = (direcao + ponto.normal) / 2;
            }
        }
        if (collision.gameObject.CompareTag("Bloquinho"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Blocão"))
        {
            collision.gameObject.GetComponent<BlocoFoda>().TomouHit();
            
        }
        if (collision.gameObject.CompareTag("Parede"))
        {
            GameManager.instance.GameOver();
            Destroy(this.gameObject);
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
