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
        static GameLoopManager _manager;
        enum GameState { Unset, Countdown, Maingame, GameOver, Paused, MainMenu }
        [Header("Game rounds")]
        float _gamestartCountdown = 0f;
        float _newcustomerCooldown = 0f;
        float _roundTime;
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
       

        static GameState _gameState = GameState.Unset;

        private void Start()
        {
            _manager = this;
            _gameState = GameState.MainMenu;
            gameoverView.SetActive(false);
            mainMenu.SetActive(true);
            countdownLabel.text = string.Empty;
            timerLabel.text = string.Empty;
            scoreLabel.text = string.Empty;
        }

        public void LaunchGameCountdown() {
            mainMenu.SetActive(false);
            _gameState = GameState.Countdown;
            countdownLabel.enabled = true;
            _gamestartCountdown = 5f;
            scorecounter = 0;
            _roundTime = roundInSeconds;
            _manager.scoreLabel.text = scorecounter + "$";
            timerLabel.text = Mathf.CeilToInt(_roundTime).ToString();
        }

        public static bool InCoreLoop() {
            return (_gameState == GameState.Maingame);
        }

        void InitializeMainGame() {
            _gameState = GameState.Maingame;
            _newcustomerCooldown = queueManager.SecondsBetweenSpawns;
        }
        public void ReloadScene() {
            SceneManager.LoadScene("MainGame");
        }

        public static void EarnScore(int addScore) {
            scorecounter += addScore;
            _manager.scoreLabel.text = scorecounter+"$";
        } 

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                switch (_gameState) {
                    case GameState.Paused:
                        timerLabel.text = Mathf.CeilToInt(_roundTime).ToString();
                        _gameState = GameState.Maingame;
                        queueManager.ToggleAgents(true);
                        return;
                    case GameState.Maingame:
                        timerLabel.text = Mathf.CeilToInt(_roundTime).ToString()+" Paused";
                        _gameState = GameState.Paused;
                        queueManager.ToggleAgents(false);
                        return;
                }
            }

            switch (_gameState) {
                case GameState.Maingame:
                    _roundTime -= Time.deltaTime;

                    timerLabel.text = Mathf.CeilToInt(_roundTime).ToString();

                    if (_roundTime <= 0) {
                        _gameState = GameState.GameOver;
                        gameoverView.SetActive(true);
                        return;
                    }

                    _newcustomerCooldown -= Time.deltaTime;
                    if (_newcustomerCooldown < 0) {
                        _newcustomerCooldown = queueManager.SecondsBetweenSpawns;
                        queueManager.SpawnNewCustomer();
                    }
                    return;
                case GameState.Countdown:
                    _gamestartCountdown -= Time.deltaTime;
                    countdownLabel.text = Mathf.CeilToInt(_gamestartCountdown).ToString();

                    if (_gamestartCountdown <= 0)
                    {
                        countdownLabel.enabled = false;
                        InitializeMainGame();
                    }
                    return;
            }
        }


    }
}