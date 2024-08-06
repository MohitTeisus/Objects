using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] private TMP_Text txtHealth;
    [SerializeField] private TMP_Text txtScore;
    [SerializeField] private TMP_Text txtHighScore;
    [SerializeField] private GameObject[] nukes;

    [Header("Menu")]
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject gameOverLabel;
    [SerializeField] private TMP_Text txtMenuHighScore;

    private Player player;  
    private ScoreManager scoreManager;
    private GameManager gameManager;
    private PickupManager pickupManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();
        scoreManager = gameManager.scoreManager;
        pickupManager = gameManager.pickUpManager;

        gameManager.OnGameStart += GameStarted;
        gameManager.OnGameOver += GameOver;   
    }


    public void UpdateHealth(float currentHealth)
    {
        currentHealth = Mathf.RoundToInt(currentHealth);
        txtHealth.SetText(currentHealth.ToString());

    }

    public void UpdateScoreUI()
    {
        txtScore.SetText(scoreManager.GetScore().ToString());
    }

    public void UpdateHighScoreUI()
    {
        txtHighScore.SetText(scoreManager.GetHighScore().ToString());
        txtMenuHighScore.SetText($"High Score: {scoreManager.GetHighScore().ToString()}");
    }

    public void UpdateNukeStorageUI(int nukeStored)
    {
        for (int i = 0; i < nukeStored; i++)
        {
            nukes[i].SetActive(true);
        }

        for (int i = nukeStored; i < nukes.Length; i++)
        {
            nukes[i].SetActive(false);
        }
    }

    public void GameStarted()
    {
        player = GameManager.GetInstance().GetPlayer();
        player.health.OnHealthUpdate += UpdateHealth;
        

        menuCanvas.SetActive(false);
    }

    public void GameOver()
    {
        gameOverLabel.SetActive(true);
        menuCanvas.SetActive(true);
    }
}
