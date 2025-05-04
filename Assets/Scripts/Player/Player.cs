using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = new Inventory(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
