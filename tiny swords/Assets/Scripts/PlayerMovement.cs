using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public int facingDirection = 1;
    public Rigidbody2D rb;
    public Animator animator;


    // Update is called once per frame
    // FixedUpdate is called before physics calculations (50 times per second)
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        if (Horizontal > 0 && transform.localScale.x < 0 || Horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        animator.SetFloat("horizontal", Mathf.Abs(Horizontal));
        animator.SetFloat("verical", Mathf.Abs(Vertical));
        rb.linearVelocity = new Vector2(Horizontal * speed, Vertical * speed);
        //vector2 is a 2D vector, it has x and y components , because its rigidbody2d
    }
    void Flip()
    {
            facingDirection = facingDirection * -1;
             transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
     }
// Unity’s transform system is always 3D.
// Using Vector3 ensures you don’t lose or accidentally change the z value.
// It’s standard practice, even in 2D games.
}

