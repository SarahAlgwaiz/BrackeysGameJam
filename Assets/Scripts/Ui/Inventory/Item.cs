using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item{

    public enum ItemType
    {
        Sword,
        Bow,
        Spear,
    }
    
    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Sword :       
                return Item_Assets.Instance.SwordSprite;
            case ItemType.Bow :         
                return Item_Assets.Instance.BowSprite;
            case ItemType.Spear :       
                return Item_Assets.Instance.SpearSprite;

        }
    }

}
