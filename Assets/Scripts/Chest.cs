using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int chestIndex;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPersistency.Instance.openedChests[chestIndex] == 1)
        {
            Destroy(gameObject);
        }
    }
}
