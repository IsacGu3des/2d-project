using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Cabou;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        
        Invoke("Fase", 5);
        Cabou.text = "Se Fudeu";

    }
    void Fase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
