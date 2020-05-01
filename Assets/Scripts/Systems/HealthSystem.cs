public class HealthSystem
{
    private int _health;
    private readonly int _maxHealth;

    public HealthSystem(int maxHealth)
    {
        this._maxHealth = maxHealth;
        _health = maxHealth;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void TakeDmage(int damage)
    {
        _health -= damage;

        if (_health < 0) _health = 0;
    }

    public void Heal(int heal)
    {
        _health += heal;

        if (_health > _maxHealth) _health = _maxHealth;
    }
}