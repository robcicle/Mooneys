using UnityEngine;
using static GameController;

public class UI_Management : MonoBehaviour
{
    public GameObject pauseUIObject;

    private GameController _gameController;

    private void Start()
    {
        _gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        Debug.Assert(_gameController, "ERROR: Can't find game controller");

        pauseUIObject.SetActive(_gameController.IfStateIsActive(EGameState.Paused));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            switch (_gameController.GetState())
            {
                case EGameState.Playing:
                    pauseUIObject.SetActive(false);
                    break;
                case EGameState.Paused:
                    pauseUIObject.SetActive(true);
                    break;
            }
    }

    public void Menu()
    {
        _gameController.ChangeState(GameController.EGameState.MainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
