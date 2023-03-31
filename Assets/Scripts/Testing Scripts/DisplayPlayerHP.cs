using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayerHP : MonoBehaviour
{
    private GameObject playerPersist;
    private PlayerPersistency playerStats;

    [SerializeField] private GameObject hpBar;
    private SpriteRenderer hpBarRenderer;

    [SerializeField] private GameObject Weapon;
    private SpriteRenderer weaponSprite;

    [SerializeField] private int currHealth;
    [SerializeField] private int maxHealth;

    [SerializeField] private InventoryObject playerEquipment;
    [SerializeField] private Sprite katanaSprite;
    [SerializeField] private Sprite maceSprite;
    [SerializeField] private Sprite romanSprite;
    [SerializeField] private Sprite scimitarSprite;


    // Start is called before the first frame update
    void Start()
    {
        playerPersist = GameObject.Find("PlayerPersistency");
        playerStats = playerPersist.GetComponent<PlayerPersistency>();
        hpBarRenderer = hpBar.GetComponent<SpriteRenderer>();
        currHealth = playerStats.currentHP;
        maxHealth = playerStats.maxHP;

        float cHealth = (float)currHealth;
        float mHealth = (float)maxHealth;
        hpBarRenderer.size = new Vector2((cHealth / mHealth) * 14.4f, 8f);

        weaponSprite = Weapon.GetComponent<SpriteRenderer>();
        int currentWeapon = playerEquipment.container.Items[4].item.ID;
        if(currentWeapon == 1)
        {
            weaponSprite.sprite = katanaSprite;
            weaponSprite.color = Color.white;
            Weapon.transform.localScale = new Vector3(0.09564409f, 0.09564409f, 0.09564409f);
        }
        if (currentWeapon == 3)
        {
            weaponSprite.sprite = maceSprite;
            weaponSprite.color = Color.white;
        }
        if (currentWeapon == 4)
        {
            weaponSprite.sprite = romanSprite;
            weaponSprite.color = Color.white;
        }
        if (currentWeapon == 4)
        {
            weaponSprite.sprite = scimitarSprite;
            weaponSprite.color = Color.white;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
