using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = new Inventory(10);
    }

    public void DropItem(Collectible item){
        Vector2 spawnLocation = transform.position;
        
        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

        Collectible droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
        droppedItem.DropEffect(spawnOffset); // TODO à revoir ?
    }
}
