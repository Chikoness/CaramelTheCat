using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{

    static float moveHorizontal;
    static float moveVertical;
    static float attack;
    static float cancel;

    public static float MoveHorizontal
    {
        get
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            return moveHorizontal;
        }
    }

    public static float MoveVertical
    {
        get
        {
            moveVertical = Input.GetAxisRaw("Vertical");
            return moveVertical;
        }
    }

    public static float Attack
    {
        get
        {
            attack = Input.GetAxisRaw("Jump");

            if (GameManager.life == -1)
            {
                attack = 0;
            }

            return attack;
            
        }
    }

    public static float Cancel
    {
        get
        {
            cancel = Input.GetAxisRaw("Cancel");
            return cancel;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
