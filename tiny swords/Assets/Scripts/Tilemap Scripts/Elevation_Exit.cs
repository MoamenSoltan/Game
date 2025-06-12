using UnityEngine;
//notes : i used the exit script to make some adjustments to the elevation mountain grid (using the boundary collider logic) , to make the player not collide with the elevations if hes out of the mountain

public class Elevation_Exit : MonoBehaviour
{
    public Collider2D [] mountainColliders;
    public Collider2D [] boundaryColliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = true;
            }
            foreach (Collider2D boundary in boundaryColliders)
            {
                boundary.enabled = false;
            }
            //enable the player collider
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
            //make the player visible under the mountain
        }
    }
}
//this is used in an empty component in non-collisions low tilemap 
//with different box colliders at the bottom of stairs