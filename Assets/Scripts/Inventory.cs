using UnityEngine;
using System.Collections.Generic;

[System.Serializable] 
public class Inventory
{
    [System.Serializable]
    public class Slot{
        // TODO bonne idée de faire ça ? -> créer un script à part
        public CollectibleType _type;
        public int _count;
        public int _maxAllowed;

        public Slot(CollectibleType item = CollectibleType.NONE){
            _type = item;
            _count = 0;
            _maxAllowed = 10;
        }

        public bool stillSpace(){
            return _count < _maxAllowed;
        }
        public void AddItem(){
            _count++;
        }

        public void AddNewItem(CollectibleType item){
            _type = item;
            AddItem();
        }
    }

    public List<Slot> _slots = new List<Slot>();


    public Inventory(int nbSlots){
        for(int i = 0; i < nbSlots; i++){
            _slots.Add(new Slot());
        }
    }

    public void Add(CollectibleType someItem){
        // TODO return bool?
        // TODO utiliser un dictionnaire à la place ?
        // public Dictionary<CollectibleType, int> _slots = new Dictionary<CollectibleType, int>();
        foreach(Slot item in _slots){
            if(someItem == item._type && item.stillSpace()){
                item.AddItem();
                return;
            }

            if(item._type == CollectibleType.NONE){
                item.AddNewItem(someItem);
                return;
            }
        }
    }
}
