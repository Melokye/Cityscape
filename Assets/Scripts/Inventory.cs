using UnityEngine;
using System.Collections.Generic;

[System.Serializable] 
public class Inventory
{
    [System.Serializable]
    public class Slot{
        // TODO bonne idée de faire ça ? -> créer un script à part ?
        // TODO possible de combiner itemType et itemIcon ?
        public CollectibleType itemType;
        public Sprite itemIcon; 
        public int _count;
        public int _maxAllowed;

        public Slot(Collectible someItem = null){
            if(someItem != null){
                itemType = someItem.type;
                itemIcon = someItem.icon;
            }else{
                // TODO améliorable ?
                itemType = CollectibleType.NONE;
                itemIcon = null;
            }
            _count = 0;
            _maxAllowed = 10;
        }

        public bool stillSpace(){
            return _count < _maxAllowed;
        }
        public void AddItem(){
            _count++;
        }

        public void AddItem(Collectible someItem){
            itemType = someItem.type;
            itemIcon = someItem.icon;
            AddItem();
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int nbSlots){
        for(int i = 0; i < nbSlots; i++){
            slots.Add(new Slot());
        }
    }

    public void Add(Collectible someItem){
        // TODO return bool?
        // TODO utiliser un dictionnaire à la place ?
        // public Dictionary<CollectibleType, int> _slots = new Dictionary<CollectibleType, int>();
        foreach(Slot slot in slots){

            // TODO remplaçable par un switch ?
            if(someItem.type == slot.itemType && slot.stillSpace()){
                slot.AddItem();
                return;
            }

            if(slot.itemType == CollectibleType.NONE){
                slot.AddItem(someItem);
                return;
            }
        }
    }
}
