using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    [SerializeField] Player player;
    private void Awake()
    {
        inventory = new Inventory();
        itemSlotContainer = transform.Find("ItemSlotConteiner");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    public void switchBetweenInventory(){
      inventory.moveToNext();
     itemSlotTemplate.GetChild(0).GetComponent<Image>().sprite = (inventory.GetItemList())[inventory.index].GetSprite();
     switch((inventory.GetItemList())[inventory.index].itemType){
         case Item.ItemType.Bow:
            player.transform.Find("Body").Find("Sword").gameObject.SetActive(false);
            player.transform.Find("Body").Find("Bow").gameObject.SetActive(true);
         break;
           case Item.ItemType.Sword:
             player.transform.Find("Body").Find("Bow").gameObject.SetActive(false);
            player.transform.Find("Body").Find("Sword").gameObject.SetActive(true);
         break;
     }
    }

    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform =  Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize,y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Icon").GetComponent<Image>();
            x++;
            if(x>4)
            {
                x = 0;
                y++;
            }

        }
    }
}
