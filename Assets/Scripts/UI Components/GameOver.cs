using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour
{

    Image gameOverScreen;
    RawImage blackScreen;

    void Awake ()
    {
        gameOverScreen = GetComponentInChildren<Image>();
        blackScreen = GetComponentInChildren<RawImage>();
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (GameManager.GameState == State.GameOver)
        {
            gameOverScreen.enabled = true;
            blackScreen.enabled = true;
        }
        else
        {
            gameOverScreen.enabled = false;
            blackScreen.enabled = false;
        }
	}
}
