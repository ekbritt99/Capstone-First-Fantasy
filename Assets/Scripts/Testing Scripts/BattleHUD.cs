using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Slider hpSlider;

    public void setHUD(int maxHP, int currentHP)
    {
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;
    }
    public void setHP(int hp)
    {
        hpSlider.value = hp;
    }
}
