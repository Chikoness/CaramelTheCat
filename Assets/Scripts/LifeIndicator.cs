using UnityEngine;
using System.Collections;

public class LifeIndicator : MonoBehaviour
{

    Animator lifeAnim;
    public static SpriteRenderer lifeRenderer;

    void Awake ()
    {
        lifeAnim = GetComponentInChildren<Animator>();
        lifeRenderer = GetComponentInChildren<SpriteRenderer>();
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    switch (GameManager.life)
        {
            case 0:
                lifeAnim.SetTrigger("Life_0");
                lifeRenderer.enabled = false;
                break;

            case 1:
                lifeAnim.SetTrigger("Life_1");
                lifeRenderer.enabled = true;
                break;

            case 2:
                lifeAnim.SetTrigger("Life_2");
                lifeRenderer.enabled = true;
                break;

            case 3:
                lifeAnim.SetTrigger("Life_3");
                lifeRenderer.enabled = true;
                break;

            case 4:
                lifeAnim.SetTrigger("Life_4");
                lifeRenderer.enabled = true;
                break;

            case 5:
                lifeAnim.SetTrigger("Life_5");
                lifeRenderer.enabled = true;
                break;
        }
	}
}
