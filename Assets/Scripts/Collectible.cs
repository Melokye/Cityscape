using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleType type;
    // public float rotationSpeed = 0.5f;
    public GameObject onCollectEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Player player = other.GetComponent<Player>();

        if (player != null) { // TODO null non nécessaire
            player._inventory.Add(type);
            Destroy(gameObject);

            // Instantiate the particle effect
            // Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }
}

public enum CollectibleType{
    // TODO rename to seed?
    NONE, SEED
}