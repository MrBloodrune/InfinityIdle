using System;
using System.Collections;
using UnityEngine;

namespace InfinityIdle.Core
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("GameManager");
                        _instance = go.AddComponent<GameManager>();
                    }
                }
                return _instance;
            }
        }

        [Header("Core Managers")]
        private SaveManager saveManager;
        private CurrencyManager currencyManager;
        private UpdateManager updateManager;
        private EventBus eventBus;

        [Header("Game State")]
        public GameState CurrentState { get; private set; }
        public bool IsInitialized { get; private set; }

        public enum GameState
        {
            Loading,
            Playing,
            Paused,
            Saving
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
            
            InitializeManagers();
        }

        private void InitializeManagers()
        {
            eventBus = new EventBus();
            
            GameObject managersContainer = new GameObject("Managers");
            managersContainer.transform.SetParent(transform);

            saveManager = managersContainer.AddComponent<SaveManager>();
            currencyManager = managersContainer.AddComponent<CurrencyManager>();
            updateManager = managersContainer.AddComponent<UpdateManager>();
        }

        private void Start()
        {
            StartCoroutine(InitializeGame());
        }

        private IEnumerator InitializeGame()
        {
            CurrentState = GameState.Loading;
            
            yield return saveManager.Initialize();
            yield return currencyManager.Initialize();
            yield return updateManager.Initialize();

            eventBus.Publish(new GameInitializedEvent());
            
            CurrentState = GameState.Playing;
            IsInitialized = true;
            
            Debug.Log("Game initialized successfully!");
        }

        public void ChangeState(GameState newState)
        {
            GameState oldState = CurrentState;
            CurrentState = newState;
            eventBus.Publish(new GameStateChangedEvent(oldState, newState));
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                ChangeState(GameState.Paused);
                saveManager.Save();
            }
            else
            {
                ChangeState(GameState.Playing);
            }
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus && CurrentState == GameState.Playing)
            {
                saveManager.Save();
            }
        }

        private void OnApplicationQuit()
        {
            saveManager.Save();
        }
    }

    public class GameInitializedEvent { }
    
    public class GameStateChangedEvent
    {
        public GameManager.GameState OldState { get; }
        public GameManager.GameState NewState { get; }

        public GameStateChangedEvent(GameManager.GameState oldState, GameManager.GameState newState)
        {
            OldState = oldState;
            NewState = newState;
        }
    }
}