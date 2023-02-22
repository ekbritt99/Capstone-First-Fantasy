using System;
using UnityEngine;

[Serializable]
public class ItemBuff
{
    public Attribute stat;
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
        GenerateAttribute();
    }


    public void AddValue(int v)
    {
        v += value;
    }

    public void GenerateAttribute()
    {
        value = UnityEngine.Random.Range(min, max);
    }

}

public enum Attributes
{
    strength,
    agility
}