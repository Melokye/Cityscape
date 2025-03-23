using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleType type = CollectibleType.NONE;
    public Sprite icon;
    // public float rotationSpeed = 0.5f;
    // public GameObject onCollectEffect;

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Player player = other.GetComponent<Player>();

        if (player != null) { // TODO null non nécessaire
            player.inventory.Add(this);
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