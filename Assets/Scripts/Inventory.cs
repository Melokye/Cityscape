using UnityEngine;
using System.Collections.Generic;

[System.Serializable] 
public class Inventory
{
    [System.Serializable]
    public class Slot{
        // TODO bonne idée de faire ça ? -> créer un script à part ?
        // TODO possible de combiner itemType et itemIcon ?
        // TODO rendre les attributs privés
        public CollectibleType itemType;
        public Sprite itemIcon; 
        public int _count;
        public int _maxAllowed;

        public Slot(Collectible someItem = null){
            if(someItem != null){
                itemType = someItem.type;
                itemIcon = someItem.GetSprite();
            }else{
                ClearItem();
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
            itemIcon = someItem.GetSprite();
            AddItem();
        }

        public void RemoveItem(){
            if(_count > 0){
                _count--;
                if(_count == 0){
                    ClearItem();
                }
            }
        }

        private void ClearItem(){
            itemType = CollectibleType.NONE;
            itemIcon = null;
            _count = 0;
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
        foreach(Slot slot in slots){
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

    public void Remove(int index){
        slots[index].RemoveItem();
    }
}
