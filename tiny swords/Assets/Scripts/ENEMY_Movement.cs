using UnityEngine;

public class ENEMY_Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // note : with enemies , we want to spawn the enemies at runtime dynamically , so we cant just pass the rigid body from inspector , here we get the component manually
    
    private Rigidbody2D rb;
    
    public float speed;
    private int facingDirection = 1;
    public float attackRange = 1f;
    private EnemyState enemyState; //store current state
    private Transform player ;//should also be dynamic but later

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //dynamic at runtime , by searching the game object itself for the rigidbody
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState==EnemyState.Chasing)
        {
            Chase();
        }
        else if (enemyState==EnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Stop moving when not chasing
        }

    
    }

    void Chase () {
        Debug.Log(Vector2.Distance(transform.position, player.transform.position));
        if (Vector2.Distance(transform.position,player.transform.position)<= attackRange)
        {
            ChangeState(EnemyState.Attacking);
        }
            else if(player.position.x >transform.position.x && facingDirection==-1 || player.position.x <transform.position.x && facingDirection==1)
            {
                Flip();
            }
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;

    }
    void Flip () {
        facingDirection *= -1;
        transform.localScale = new Vector3(facingDirection, transform.localScale.y, transform.localScale.z);
    }

    void ChangeState (EnemyState newState) {
        //exit the current animation
        if (enemyState == EnemyState.Idle)
        anim.SetBool("isIdle",false);
        else if (enemyState == EnemyState.Chasing)
        anim.SetBool("isChasing",false);
        else if (enemyState == EnemyState.Attacking)
        anim.SetBool("isAttacking",false);

        //update our current state
        enemyState = newState;


        //update the new animation
        if (enemyState == EnemyState.Idle)
        anim.SetBool("isIdle",true);
        else if (enemyState == EnemyState.Chasing)
        anim.SetBool("isChasing",true);
        else if (enemyState == EnemyState.Attacking)
        anim.SetBool("isAttacking",true);
    }

    private void OnTriggerStay2D(Collider2D collision)//in trigger enter and exit , we just modify some states , the actual modification is im update based on the change we made here
    {
        if (collision.gameObject.CompareTag("Player")) {
            
            if(player == null)
            {
                player = collision.transform;
                //condition to only do it once
                //other is collision data
            }
            

            ChangeState(EnemyState.Chasing);//from enum not enemyState because it only stores the current animation
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

            rb.linearVelocity = Vector2.zero; // Stop moving when not chasing
            ChangeState(EnemyState.Idle);
        }
        
    }
    
}

//now we are making a state machine for the enemy
//outside brackets for better readability (encapsulation) and still public so that other scripts can access it

public enum EnemyState {//remember any usage of this enum , must be preceeded by EnemyState.
    Idle,
    Chasing,

    Attacking,
}