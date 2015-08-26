using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Points : MonoBehaviour
{

    Text pointer;

    void Awake ()
    {
        pointer = GetComponentInChildren<Text>();
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.hasGameStarted == false)
        {
            pointer.text = (0).ToString();
        }
        else
        {
            pointer.text = GameManager.points.ToString();
        }

        if (GameManager.GameState == State.GameOver)
        {
            
        }
	}
}
