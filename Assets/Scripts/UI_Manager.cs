using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Manager : MonoBehaviour
{

    Canvas menuScreen;

    void Awake()
    {
        menuScreen = GetComponentInChildren<Canvas>();
    }

	// Use this for initialization
	void Start ()
    {

	}

    // Update is called once per frame
    void Update()
    {
        if (GameManager.hasGameStarted && GameManager.GameState == State.Pause && GameManager.GameState != State.Menu)
        {
            GameManager.GameState = State.Pause;
            menuScreen.enabled = true;
        }
        else if (GameManager.GameState == State.Menu)
        {
            menuScreen.enabled = true;
        }
    }

    void OnEnable ()
    {
    
    }

    void StartGameButtonListener ()
    {
        if (GameManager.hasGameStarted && GameManager.GameState == State.Pause)
        {
            GameManager.GameState = State.Play;
            menuScreen.enabled = false;
        }
        else
        {
            GameManager.hasGameStarted = true;
            GameManager.GameState = State.Play;
            menuScreen.enabled = false;
        }

    }

    void ExitGameButtonListener ()
    {
        Application.Quit();
    }
}
