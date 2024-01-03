using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas = 2;
    public int TijolosR;
    
    public GameObject playerPrefab;
    public GameObject ballPrefab;
    public Transform playerspawnpoint;
    public Transform ballspawnpoint;
    
    public PlayerB playerAtual;
    public BallB ballAtual;

    public TextMeshProUGUI contador;
    public TextMeshProUGUI msgFinal;

    public bool segurando;
    private Vector3 offset;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewPlayer();
        AtualizarContador();
        TijolosR = GameObject.FindGameObjectsWithTag("Tijolo").Length;
    }

    public void AtualizarContador()
    {
        contador.text = $"Vidas: {vidas} ";
    }

    public void SpawnNewPlayer()
    {
        GameObject playerObj = Instantiate(playerPrefab, playerspawnpoint.position, Quaternion.identity);
        GameObject ballObj = Instantiate(ballPrefab, ballspawnpoint.position, Quaternion.identity);

        playerAtual = playerObj.GetComponent<PlayerB>();
        ballAtual = ballObj.GetComponent<BallB>();
        segurando = true;
        offset = playerAtual.transform.position - ballAtual.transform.position;
    }

    public void subtrairTijolo()
    {
        TijolosR--;

        if (TijolosR <= 0)
        {
            Vitoria();
        }
    }

    public void SubtrairVida()
    {
        vidas--;
        AtualizarContador();
        Destroy(playerAtual.gameObject);
        Destroy(ballAtual.gameObject);
        if (vidas <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(SpawnNewPlayer), 2);
        }

    }

    public void Vitoria()
    {
        msgFinal.text = "Parabéns";
        Destroy(ballAtual.gameObject);
        Invoke(nameof(Reiniciarscene), 2);
    }

    public void GameOver()
    {
        msgFinal.text = "Game Over";
        Invoke(nameof(Reiniciarscene), 2);
    }

    public void Reiniciarscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (segurando)
        {
            ballAtual.transform.position = playerAtual.transform.position - offset;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ballAtual.DispararBolinha(playerAtual.inputX);
                segurando = false;
            }

        }
    }
}
