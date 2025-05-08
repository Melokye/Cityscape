using UnityEngine;
using System.Collections.Generic;

[System.Serializable] // TODO delete
public class Inventory_UI : BaseUI
{
    public GameObject inventoryPanel; // TODO private
    public Player player;

    public List<Slot_UI> slots = new List<Slot_UI>();

    void Start(){
        Close();
        Transform slots_ui = inventoryPanel.transform.Find("Slots");
        for(int i = 0; i < player.inventory.slots.Count; i++){
            // GameObject child = new GameObject("Slot_UI");
            // child.transform.SetParent(slots_ui);
            // slots.Add(child);
            slots.Add(slots_ui.GetChild(i).GetComponent<Slot_UI>());
            // TODO add component
        }
    }

    public override void Open() {
        gameObject.SetActive(true);
        Refresh(); // TODO à appeler à un autre moment => supp override
    }

    public void Remove(int slotID){
        // TODO insert slotID dans les attributs directement
        // TODO trouver une alternative pour itemToDrop
        Collectible itemToDrop = 
            GameManager.instance.itemManager.GetItemByType(player.inventory.slots[slotID].itemType);

        if(itemToDrop != null){
            player.DropItem(itemToDrop);
            player.inventory.Remove(slotID);
            Refresh();
        }
    }

    void Refresh(){
        // if(slots.Count != player.inventory.slots.Count){return;}

        // TODO possible de fusionner directement de façon opti ?
        // TODO test si on change le type d'objet, MAJ ?
        for(int i = 0; i < slots.Count; i++){
            if(player.inventory.slots[i].itemType != CollectibleType.NONE){
                slots[i].SetItem(player.inventory.slots[i]);
            }else{
                slots[i].SetEmpty();
            }
        }
    }
}
