using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int MaxHealth { get; }
    private float MaxMana { get; }
    private float regenRate { get; set; }
    private int health { get; set; }
    private float mana { get; set; }

    public PlayerStats()
    {
        this.MaxHealth = 100;
        this.MaxMana = 100.0f;
        this.regenRate = 0.5f;
        this.health = this.MaxHealth;
        this.mana = this.MaxMana;
    }
    
    public void SubtractHealth(int health, bool exact)
    {
        this.health -= health;
        if(this.health < 0 && !exact)
        {
            this.health = 0;
        } 
        else
        {
            this.health += health;
        }
    }

    public void AddHealth(int health)
    {
        this.health += health;
        if(this.health > this.MaxHealth)
        {
            this.health = this.MaxHealth;
        }
    }

    public void SubtractMana(float mana, bool exact)
    {
        this.mana -= mana;
        if (this.mana < 0 && !exact)
        {
            this.mana = 0;
        }
        else
        {
            this.mana += mana;
        }
    }

    public void AddMana(int mana)
    {
        this.mana += mana;
        if (this.mana > this.MaxMana)
        {
            this.mana = this.MaxMana;
        }
    }

    public void RegenMana()
    {
        if(this.mana < this.MaxMana)
        {
            this.mana += this.regenRate * Time.fixedDeltaTime;
        }
    }

    public bool isAlive()
    {
        return this.health > 0;
    }

    void Update()
    {
        RegenMana();
    }

}
