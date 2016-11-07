using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float startingHealth = 100;
    public Slider healthBar;
    private float currentHealth;

    public void TakeDamage()
    {
        currentHealth -= 10;
        UpdateHealthBar();
    }
       
    private void OnEnable()
    {
        currentHealth = startingHealth;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }
}
