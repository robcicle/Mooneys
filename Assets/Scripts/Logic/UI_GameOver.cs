using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameOver : MonoBehaviour
{
    private GameController _gameController;

    [SerializeField]
    private TextMeshProUGUI _prevPlayerScore;
    [SerializeField]
    private string playerScoreString = "SCORE: ";

    private void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        Debug.Assert(_gameController, "ERROR: Can't find game controller");
        _prevPlayerScore.text = playerScoreString + _gameController.GetPrevScore();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        _gameController.ChangeState(GameController.EGameState.MainMenu);
    }

    public void PlayGame()
    {
        _gameController.ChangeState(GameController.EGameState.Playing);
    }
}
