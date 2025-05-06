using UnityEngine;
using System.Collections.Generic;
// TODO : voir s'il y a pas d'autres alternatives ?
// [System.Serializable]
public class ItemManager : MonoBehaviour
{
    public Collectible[] collectableItems;

    private Dictionary<CollectibleType, Collectible> collectableItemsDict = new Dictionary<CollectibleType, Collectible>();
   
    private void Awake(){
        foreach (Collectible item in collectableItems)
        {
            AddItem(item);   
        }
    }

    private void AddItem(Collectible item){
        if(!collectableItemsDict.ContainsKey(item.type)){
            collectableItemsDict.Add(item.type, item);
        }
    }

    public Collectible GetItemByType(CollectibleType type){
        if(collectableItemsDict.ContainsKey(type)){
            return collectableItemsDict[type];
        }
        return null;
    }
}
