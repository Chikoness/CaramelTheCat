using UnityEngine;
using System.Collections;

public enum PlayerState
{
    Idle,
    Walk,
    Attack,
    Hurt
}

public class PlayerController : MonoBehaviour

{

    public float speed = 5f;
    public PlayerState CatState = PlayerState.Idle;

    Rigidbody2D catRb2D;
    Animator catAnim;
    SpriteRenderer catRenderer;
    AudioSource catAudioSource;

    void Awake()
    {
        catRb2D = GetComponent<Rigidbody2D>();
        catAnim = GetComponentInChildren<Animator>();
        catRenderer = GetComponentInChildren<SpriteRenderer>();
        catAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(HurtManager());
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        if (GameManager.GameState == State.Play)
        {

            if (InputManager.Attack > 0) // attack 
            {
                catAnim.SetTrigger("Cat_Attack");
                CatState = PlayerState.Attack;
            }
            else if (Mathf.Approximately(InputManager.Attack, 0) && CatState == PlayerState.Attack)
            {
                catAnim.SetTrigger("Cat_Idle");
                CatState = PlayerState.Idle;
            }
            
            if (InputManager.MoveHorizontal > 0) // move horizontally
            {
                catRb2D.velocity = Vector2.right * speed;
                if (CatState != PlayerState.Attack)
                {
                    catAnim.SetTrigger("Cat_Walk");
                    CatState = PlayerState.Walk;
                }
            }
            else if (InputManager.MoveHorizontal < 0)
            {
                catRb2D.velocity = Vector2.left * speed;
                if (CatState != PlayerState.Attack)
                {
                    catAnim.SetTrigger("Cat_Walk");
                }
                CatState = PlayerState.Walk;
            }
            else if (InputManager.MoveVertical > 0) // move vertically
            {
                catRb2D.velocity = Vector2.up * speed;
                if (CatState != PlayerState.Attack)
                {
                    catAnim.SetTrigger("Cat_Walk");
                    CatState = PlayerState.Walk;
                }
            }
            else if (InputManager.MoveVertical < 0)
            {
                catRb2D.velocity = Vector2.down * speed;
                if (CatState != PlayerState.Attack)
                {
                    catAnim.SetTrigger("Cat_Walk");
                    CatState = PlayerState.Walk;
                }
            }
            else // if nothing is pressed...
            {
                catRb2D.velocity = Vector2.zero;
            }
            

            if (Mathf.Approximately(catRb2D.velocity.x, 0) && 
                Mathf.Approximately(catRb2D.velocity.y, 0) &&
                CatState != PlayerState.Attack) // if not attacking or moving
            {
                catAnim.SetTrigger("Cat_Idle");
                CatState = PlayerState.Idle;

            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) //when cat gets hurt
    {
        if (GameManager.GameState == State.Play)
        {
            if (CatState != PlayerState.Attack && collision.tag == "Mob")
            {
                CatState = PlayerState.Hurt;
                
            }
        }
    }


    IEnumerator HurtManager() //cat hurt manager
    {
        while (true)
        {
            if (GameManager.GameState == State.Play)
            {
                if (CatState == PlayerState.Hurt)
                {
                    catAudioSource.Play();
                    for (int i = 0; i < 2; i++)
                    {
                        catRenderer.color = new Color (1.0f, 0.0f, 0.0f, 0.5f);

                        yield return new WaitForSeconds(0.05f);

                        catRenderer.color = Color.white;
                    }
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

}
