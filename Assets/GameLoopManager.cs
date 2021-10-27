using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace LegoInterview
{
    public class GameLoopManager : MonoBehaviour
    {
        enum GameState { Unset, Countdown, Maingame, Victory, Paused }
        [Header("Game rounds")]
        float gamestartCountdown = 0f;
        float newcustomerCooldown = 0f;
        public ShopQueueManager queueManager;    

        [Header("Labels")]
        public TextMeshProUGUI scoreLabel;
        public TextMeshProUGUI timerLabel;
        public TextMeshProUGUI countdownLabel;

        static GameState gameState = GameState.Unset;

        private void Start()
        {
            gameState = GameState.Countdown;
            countdownLabel.enabled = true;
            gamestartCountdown = 5f;
        }

        public static bool InCoreLoop() {
            return (gameState == GameState.Maingame);
        }

        void InitializeMainGame() {
            gameState = GameState.Maingame;
            newcustomerCooldown = queueManager.SecondsBetweenSpawns;
        }

        private void Update()
        {
            switch (gameState) {
                case GameState.Maingame:
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