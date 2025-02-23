using UnityEngine;

public class Soil : MonoBehaviour
{
    private bool isWet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        isWet = false;
    }

    public void TakeWater(){
        isWet = true;
        
    // TODO sprite mouillé
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
