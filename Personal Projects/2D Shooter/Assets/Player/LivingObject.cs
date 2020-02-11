using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingObject
{
    private int maxHealth;
    private int currentHealth;

    public LivingObject(int health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void heal(int health)
    {
        if (currentHealth != maxHealth)
        {
            currentHealth += health;
        }
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }
}
