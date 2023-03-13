using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Persistent Unit", menuName = "Persistent Unit")]
public class PersistentEntityUnit : ScriptableObject
{
    public int damage;
    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if(currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if(currentHP > maxHP)
            currentHP = maxHP;
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        currentHP = maxHP;
    }
}
