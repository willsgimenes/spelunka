using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    private HealthSystem _healthSystem;
    public HealthBar healthBar;

    private void Start()
    {
        _healthSystem = new HealthSystem(100);
        healthBar.SetMaxHealth(_healthSystem.GetHealth());
    }

    private void Update()
    {
        Restart();
    }

    public void Hit()
    {
        _healthSystem.TakeDmage(10);
        healthBar.SetHealth(_healthSystem.GetHealth());
        transform.position = GameObject.FindWithTag("RespawnPoint").transform.position;
    }

    public void Exit()
    {
        transform.position = GameObject.FindWithTag("RespawnPoint").transform.position;
    }

    private void Restart()
    {
        if (!Input.GetKey(KeyCode.Z)) return;
        
        _healthSystem.Heal(100);
        healthBar.SetMaxHealth(_healthSystem.GetHealth());
    }
}
