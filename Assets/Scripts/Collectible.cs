using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // TODO SerializeField private 
    public CollectibleType type = CollectibleType.NONE;
    private Sprite _icon;
    // public float rotationSpeed = 0.5f;
    // public GameObject onCollectEffect;

    private Rigidbody2D _rb;

    void Awake(){
        _rb = GetComponent<Rigidbody2D>();
    }

    public void DropEffect(Vector2 offset){
        // _rb.AddForce(offset, ForceMode2D.Impulse);
        // TODO à réajuster
    }


    void Start(){
        _icon = GetComponent<SpriteRenderer>().sprite;
    }
    void Update()
    {
        // transform.Rotate(0, 0, rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Player player = other.GetComponent<Player>();

        if (player != null) { // TODO null non nécessaire
            player.inventory.Add(this);
            Destroy(gameObject);

            // Instantiate the particle effect
            // Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }

    public Sprite GetSprite(){
        return _icon;
    }
}

public enum CollectibleType{
    // TODO rename to seed?
    NONE, SEED
}