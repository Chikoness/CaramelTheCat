using UnityEngine;
using System.Collections;

public enum State
{
    Play,
    Menu,
    Pause,
    GameWon,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public State State;

    public static State GameState;
    public static bool hasGameStarted = false;
    public static int points = 0;
    public static int timer = 0;
    public static int life = 5;

    void Awake ()
    {
        GameState = State;
    }

    void Start ()
    {
        StartCoroutine(InputHandler());
    }

    void Update ()
    {
        State = GameState;

        if (life == -1)
        {
            GameState = State.GameOver;
            life = 5;
            hasGameStarted = false;
        }

        switch (GameState)
        {
            case State.Play:                
                Time.timeScale = 1;
                break;

            case State.Menu:
                if (!hasGameStarted)
                {
                    points = 0;
                }
                Time.timeScale = 0;                
                break;

            case State.Pause:
                Time.timeScale = 0;
                break;

            case State.GameWon:
                Time.timeScale = 0;
                break;

            case State.GameOver:
                Time.timeScale = 0;
                if (Input.anyKey && !Input.GetKey(KeyCode.Space))
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
                break;
        }
        Debug.Log(life);
    }

    IEnumerator InputHandler()
    {
        while (true)
        {
            if (InputManager.Cancel > 0 && GameState == State.Play)
            {
                GameState = State.Pause;
            }

            yield return new WaitForEndOfFrame();
        }
    }
    

}
