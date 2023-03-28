using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    private GameController _gameController;

    private void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        Debug.Assert(_gameController, "ERROR: Can't find game controller");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        _gameController.ChangeState(GameController.EGameState.Playing);
    }
}
