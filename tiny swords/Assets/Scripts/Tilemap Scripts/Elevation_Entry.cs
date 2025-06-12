using UnityEngine;
//very important notes , make sure the caught collider (the one we drag and drop) is a tilemap collider not the composite collider , or else it wont work

public class Elevation_Entry : MonoBehaviour
{
    public Collider2D [] mountainColliders;
    public Collider2D [] boundaryColliders;
    //boundary colliders can be a variable not array

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                    //collision here is the player
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = false;
            }
            foreach (Collider2D boundary in boundaryColliders)
            {
                boundary.enabled = true;
            }
        //disable the player collider
        collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        //make the player visible over the mountain
        
        }
    }
    
}
