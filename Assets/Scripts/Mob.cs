using UnityEngine;
using System.Collections;

public enum MobState
{
    Idle,
    Break,
    Die
}

public class Mob : MonoBehaviour
{

    public MobState EnemyState = MobState.Idle;
    public string animBreakTrigger;
    public float torque = 60f;

    Rigidbody2D mobRb2D;
    Animator mobAnim;
    BoxCollider2D mobCol;
    SpriteRenderer mobRenderer;

    void Awake()
    {

        mobRb2D = GetComponent<Rigidbody2D>();
        mobAnim = GetComponentInChildren<Animator>();
        mobCol = GetComponent<BoxCollider2D>();
        mobRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    void Start()
    {
        mobRb2D.AddTorque(Random.Range(-torque, torque), ForceMode2D.Impulse);
        StartCoroutine(DieManager());
    }

    void Update() //Die
    {
        if (GameManager.GameState == State.Play)
        {
            switch(EnemyState)
            {
                case MobState.Idle:
                    break;

                case MobState.Break:
                    break;
            }
        }
    }

    void FixedUpdate()
    {

    }
    
    void OnTriggerStay2D(Collider2D collision) //Collision + what happens when die
    {
        if (GameManager.GameState == State.Play)
        {
            if (collision.tag == "Player")
            {
                
                mobRb2D.drag = 10.0f; 

                if (collision.GetComponent<PlayerController>().CatState == PlayerState.Attack)
                {
                    GameManager.points++;
                    EnemyState = MobState.Break;
                }

                else
                {
                    GameManager.life--;
                    EnemyState = MobState.Die;
                }
            }
        }
    }

    void OnTriggerExit2D (Collider2D collision)
    {
        if (GameManager.GameState == State.Play)
        {
            if (collision.tag == "OffScreen")
            {
                Destroy(gameObject);
            }
        }
    }

    void OnDestroy () //Spawner
    {
        Spawner.spawned--;
    }

    IEnumerator DieManager() //Die IEnumerator
    {

        while (true)
        {
            if (GameManager.GameState == State.Play && (EnemyState == MobState.Die || EnemyState == MobState.Break))
            {
                mobCol.enabled = false;

                if (EnemyState == MobState.Break)
                {
                    mobAnim.SetTrigger(animBreakTrigger);
                }

                float i = 1;

                while (i > 0)
                {
                    i -= 2f * Time.deltaTime;
                    mobRenderer.color = new Color(1.0f, 1.0f, 1.0f, i);
                    
                    if (i <= 0)
                    {
                        DestroyImmediate(gameObject);
                        yield break;
                    }

                    yield return new WaitForEndOfFrame();
                }
            }

            yield return new WaitForEndOfFrame();
        }

    }



    //IEnumerator RandomRotator()
    //{
    //    while(true)
    //    {
    //        if (GameManager.GameState == State.Play)
    //        {
    //            mobRb2D.AddTorque(Random.Range(0, torque));
    //        }

    //        yield return new WaitForSeconds(Random.Range(0.1f, 0.5f)); 
    //    }
    //}
}
