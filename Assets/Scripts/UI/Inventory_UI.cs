using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel; // TODO automatisable ?
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();

    void Start(){
        inventoryPanel.SetActive(false);
        // for(int i = 0; i < player.inventory.slots.Count; i++){
        //     slots.Add(new Slot_UI());
        //     // TODO add component
        // }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            ToggleInventory();
        }
    }

    public void ToggleInventory(){
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        if(inventoryPanel.activeSelf){
            Setup(); // TODO rename ?
        }
    }

    void Setup(){
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
