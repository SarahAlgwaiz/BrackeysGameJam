using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Assets : MonoBehaviour
{
    public static Item_Assets Instance { get; private set;}
    
    private void Awake()
    {
        Instance = this;
    }

    public Sprite SwordSprite;
    public Sprite BowSprite;
    public Sprite SpearSprite;
    
}
