using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  
    public int CurrentHealth;
    public int MaxHealth;
    public HealthBar healthBar; //here we pass the game object that holds the script not the script itself
    
    void Start () {
        CurrentHealth = MaxHealth;
        healthBar.SetHealth(CurrentHealth);
    }

    public void ChangeHealth(int amount) {
        CurrentHealth += amount ;

        if(CurrentHealth<= 0)
        {
            gameObject.SetActive(false);
            //the gane object that this script is attached to
            
        }

        healthBar.SetHealth(CurrentHealth);
        

    }
}
