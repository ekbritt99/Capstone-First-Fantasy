
[System.Serializable]
public class Currency
{
    public int unit;

    public Currency()
    {
        unit = 30;
    }

    public Currency(int amount)
    {
        unit = amount;
    }

    public void addCurrency(int amount)
    {
        unit += amount;
    }

    public void removeCurrency(int amount)
    {
        unit -= amount;
    }

    public bool canAfford(int amount)
    {
        if(unit >= amount)
            return true;
        return false;
    }
}