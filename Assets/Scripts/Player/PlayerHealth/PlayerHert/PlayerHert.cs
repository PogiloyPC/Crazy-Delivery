using System;

public class PlayerHert : IHert
{
    private const int _maxHealth = 1;
    private int _currentHealth;

    private IViewHealth _viewHealth;

    public PlayerHert(IViewHealth viewHealth)
    {
        _currentHealth = _maxHealth;

        _viewHealth = viewHealth;
    }

    public void TakeDamage(IDamageDiller damageDiller)
    {
        int damage = 0;

        if (damageDiller.GetDamage() > _maxHealth)
            damage = 1;
        else if (damageDiller.GetDamage() <= 0)
            throw new ArgumentException("Is value less then 0");
        else
            damage = damageDiller.GetDamage();

        _currentHealth -= damage;

        _viewHealth.DisplayHealth(this);
    }

    public void ReplenishHert(IReplenishObject replenishObject)
    {
        int replenishValue = 0;

        if (replenishObject.GetReplenishValue() > _maxHealth)
            replenishValue = 1;
        else if (replenishObject.GetReplenishValue() <= 0)
            throw new ArgumentException("Is value less then 0");
        else
            replenishValue = replenishObject.GetReplenishValue();

        _currentHealth += replenishValue;

        _viewHealth.DisplayHealth(this);
    }

    public int GetCurrentHealth() => _currentHealth;

    public int GetStartHealth() => _maxHealth;
}

public interface IDisplayableHert
{
    int GetCurrentHealth();
    int GetStartHealth();
}

public interface IHert : IDisplayableHert
{
    void TakeDamage(IDamageDiller damageDiller);

    void ReplenishHert(IReplenishObject replenishObject);
}