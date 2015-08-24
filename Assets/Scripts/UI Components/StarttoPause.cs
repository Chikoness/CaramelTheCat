using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarttoPause : MonoBehaviour
{
    Text startButtonText;

    void Awake ()
    {
        startButtonText = GetComponentInChildren<Text>();
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (GameManager.GameState == State.Pause)
        {
            startButtonText.text = "Resume Game";
        }
	}
}
