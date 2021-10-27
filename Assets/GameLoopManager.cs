using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace LegoInterview
{
    public class GameLoopManager : MonoBehaviour
    {
        static GameLoopManager manager;
        enum GameState { Unset, Countdown, Maingame, GameOver, Paused, MainMenu }
        [Header("Game rounds")]
        float gamestartCountdown = 0f;
        float newcustomerCooldown = 0f;
        float roundTime;
        public float roundInSeconds = 60f;
        public ShopQueueManager queueManager;

        static int scorecounter = 0;

        [Header("Labels")]
        public TextMeshProUGUI scoreLabel;
        public TextMeshProUGUI timerLabel;
        public TextMeshProUGUI countdownLabel;

        [Header("Menu")]
        public GameObject mainMenu;
        public GameObject gameoverView;
       

        static GameState gameState = GameState.Unset;

        private void Start()
        {
            manager = this;
            gameState = GameState.MainMenu;
            gameoverView.SetActive(false);
            mainMenu.SetActive(true);
            countdownLabel.text = string.Empty;
            timerLabel.text = string.Empty;
            scoreLabel.text = string.Empty;
        }

        public void LaunchGameCountdown() {
            mainMenu.SetActive(false);
            gameState = GameState.Countdown;
            countdownLabel.enabled = true;
            gamestartCountdown = 5f;
            scorecounter = 0;
            roundTime = roundInSeconds;
            manager.scoreLabel.text = scorecounter + "$";
            timerLabel.text = Mathf.CeilToInt(roundTime).ToString();
        }

        public static bool InCoreLoop() {
            return (gameState == GameState.Maingame);
        }

        void InitializeMainGame() {
            gameState = GameState.Maingame;
            newcustomerCooldown = queueManager.SecondsBetweenSpawns;
        }
        public void ReloadScene() {
            SceneManager.LoadScene("MainGame");
        }

        public static void EarnScore(int addScore) {
            scorecounter += addScore;
            manager.scoreLabel.text = scorecounter+"$";
        } 

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                switch (gameState) {
                    case GameState.Paused:
                        timerLabel.text = Mathf.CeilToInt(roundTime).ToString();
                        gameState = GameState.Maingame;
                        queueManager.ToggleAgents(true);
                        return;
                    case GameState.Maingame:
                        timerLabel.text = Mathf.CeilToInt(roundTime).ToString()+" Paused";
                        gameState = GameState.Paused;
                        queueManager.ToggleAgents(false);
                        return;
                }
            }

            switch (gameState) {
                case GameState.Maingame:
                    roundTime -= Time.deltaTime;

                    timerLabel.text = Mathf.CeilToInt(roundTime).ToString();

                    if (roundTime <= 0) {
                        gameState = GameState.GameOver;
                        gameoverView.SetActive(true);
                        return;
                    }

                    newcustomerCooldown -= Time.deltaTime;
                    if (newcustomerCooldown < 0) {
                        newcustomerCooldown = queueManager.SecondsBetweenSpawns;
                        queueManager.SpawnNewCustomer();
                    }
                    return;
                case GameState.Countdown:
                    gamestartCountdown -= Time.deltaTime;
                    countdownLabel.text = Mathf.CeilToInt(gamestartCountdown).ToString();

                    if (gamestartCountdown <= 0)
                    {
                        countdownLabel.enabled = false;
                        InitializeMainGame();
                    }
                    return;
            }
        }


    }
}