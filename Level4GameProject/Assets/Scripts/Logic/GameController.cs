using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController _gameController = null;

    // All of the potential states.
    public enum EGameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }
    // Keep track of current state
    [SerializeField]
    private EGameState _eGameState = EGameState.MainMenu;

    int _prevScore = 0;

    private void Awake()
    {
        // Assert if there isn't already a controller.
        Debug.Assert(_gameController == null, 
            "Multiple instances of singleton has already been created", 
            this.gameObject
            );

        // Handle of the first controller created.
        _gameController = this;

        // Ensure we are in the current state,
        // and do all the required state intstructions.
        ChangeState(_eGameState);
    }

    private void Start()
    {
        // If the state is set to either menu or playing,
        // make sure the scenes needed are the ones loaded
        switch (_eGameState)
        {
            case EGameState.MainMenu:
                if (SceneManager.GetSceneByName("Game").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("Game");
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                }
                break;
            case EGameState.Playing:
                if (SceneManager.GetSceneByName("MainMenu").isLoaded)
                {
                    SceneManager.UnloadSceneAsync("MainMenu");
                    RestartGame();
                }
                break;
        }
    }

    void Update()
    {
        switch(_eGameState)
        {
            /////////////////////////////////////////////
            // Game is on main menu
            case EGameState.MainMenu:
                break;
            /////////////////////////////////////////////
            // Game is playing
            case EGameState.Playing:
                // If escaped is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    // Pause the game
                    ChangeState(EGameState.Paused);
                }
                break;
            /////////////////////////////////////////////
            // Game is paused
            case EGameState.Paused:
                // If escaped is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    // Resume the game
                    ChangeState(EGameState.Playing);
                }
                break;
            /////////////////////////////////////////////
            // Game is over
            case EGameState.GameOver:
                break;
            /////////////////////////////////////////////
            

            /////////////////////////////////////////////
            // Capure any out of state errors
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void ChangeState(EGameState eGameState)
    {
        Debug.Log("~Changing State to - " + eGameState);

        switch (eGameState)
        {
            /////////////////////////////////////////////
            // Game is on main menu
            case EGameState.MainMenu:
                if (_eGameState == EGameState.Playing || _eGameState == EGameState.Paused)
                {
                    SceneManager.UnloadSceneAsync("Game");
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                }
                else if (_eGameState == EGameState.GameOver)
                {
                    SceneManager.UnloadSceneAsync("GameOver");
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                }
                else
                {
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                }
                Time.timeScale = 0.0f;
                break;
            /////////////////////////////////////////////
            // Game is playing
            case EGameState.Playing:
                if (_eGameState == EGameState.MainMenu)
                {
                    SceneManager.UnloadSceneAsync("MainMenu");
                    RestartGame();
                }
                else if (_eGameState == EGameState.GameOver)
                {
                    SceneManager.UnloadSceneAsync("GameOver");
                    RestartGame();
                }
                Time.timeScale = 1.0f;
                break;
            /////////////////////////////////////////////
            // Game is paused
            case EGameState.Paused:
                Time.timeScale = 0.0f;
                break;
            /////////////////////////////////////////////
            // Game is over
            case EGameState.GameOver:
                if (_eGameState == EGameState.Playing || _eGameState == EGameState.Paused)
                {
                    SceneManager.UnloadSceneAsync("Game");
                    SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
                }
                Time.timeScale = 0.0f;
                break;
            /////////////////////////////////////////////


            /////////////////////////////////////////////
            // Capure any out of state errors
            default:
                throw new ArgumentOutOfRangeException();
        }

        // Actually set the state
        _eGameState = eGameState;
    }

    public void RestartGame()
    {
        if (SceneManager.GetSceneByName("Game").isLoaded)
        {
            Debug.Log("Game already on - unloading");
            SceneManager.UnloadSceneAsync("Game");
        }

        // Load the game scene mode - in additive to keep the management scene
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }

    public EGameState GetState()
    {
        return _eGameState;
    }

    public bool IfStateIsActive(EGameState _state)
    {
        if (_eGameState == _state)
            return true;
        else
            return false;
    }

    public void SetPrevScore(int prevScore)
    {
        _prevScore = prevScore;
    }

    public int GetPrevScore()
    {
        return _prevScore;
    }
}
