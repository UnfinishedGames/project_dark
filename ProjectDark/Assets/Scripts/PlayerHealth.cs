using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public string myName; 
    public float startingHealth = 100;
    public Slider healthBar;
    private float currentHealth;
    public CountWins counter;
    public GameObject playerSpawn;

    private void OnEnable()
    {
        currentHealth = startingHealth;
        UpdateHealthBar();
    }

    public void TakeDamage()
    {
        currentHealth -= 10;
        UpdateHealthBar();
        if(currentHealth <= 0)
        {
            counter.IAmDead(myName);
        }
    }
     
    private void UpdateHealthBar()
    {
        //healthBar.value = currentHealth;
    }
}
