using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Hit()
    {
        TakeDamage(10);
        transform.position = GameObject.FindWithTag("RespawnPoint").transform.position;
    }

    public void Exit()
    {
        transform.position = GameObject.FindWithTag("RespawnPoint").transform.position;
    }
}
