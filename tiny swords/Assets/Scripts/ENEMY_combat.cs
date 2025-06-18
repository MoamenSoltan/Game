using UnityEngine;

public class ENEMY_combat : MonoBehaviour
{

    public int damage = 10;
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask playerLayer;//to check if the player is within range
    
    //here it calls capsule collider not circle , because circle is a trigger

    /*
    How Unity Calls the Methods
OnTriggerEnter2D is only called when at least one of the colliders involved is marked as a trigger.
OnCollisionEnter2D is called when both colliders are not triggers (i.e., for physical collisions).*/
  private void OnCollisionEnter2D(Collision2D collision) {
    //fires when the enemy hits a collider
    //here in this case collision refers to what collides with enemy which is the player
    // PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
    // if (playerHealth != null) {
    //     playerHealth.ChangeHealth(-damage);
    // }
    if (collision.gameObject.tag == "Player")
    {
      collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
    }
  }

  public void Attack () {
    //an array that holds all objects the enemy hits
    Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position,weaponRange,playerLayer);//dont forget to change player to the player layer in editor
    if(hits.Length>0)//there is something to hit
    {
      hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
    }
  }
}
