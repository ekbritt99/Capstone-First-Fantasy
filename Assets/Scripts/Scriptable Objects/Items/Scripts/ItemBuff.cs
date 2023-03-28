using System;
using UnityEngine;

[Serializable]
public class ItemBuff
{
    public Attributes stat;
    public int value;
    [SerializeField]
    private int min;
    public int Min => min;
    [SerializeField]
    private int max;
    public int Max => max;



    public ItemBuff(int min, int max)
    {
        this.min = min;
        this.max = max;
        GenerateValue();
    }



    public bool IsUpgradable() {
        if(value < max)
            return true;
        return false;
    }

    public void UpgradeStat(int v)
    {
        value += v;
        if(value > max)
        {
            value = max;
        }
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }

}

public enum Attributes
{
    Strength,
    Agility,
    Intellect,
    Defense,
    Healing
}