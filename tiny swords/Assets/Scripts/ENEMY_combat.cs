using UnityEngine;

public class ENEMY_combat : MonoBehaviour
{

    public int damage = 10;
    
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
}
