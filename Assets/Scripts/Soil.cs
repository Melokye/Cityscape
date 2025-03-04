using UnityEngine;

public class Soil : MonoBehaviour
{
    private bool m_isWet;
    private string m_plant; // TODO use object instead
    private int m_days;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        m_isWet = false;
        m_days = 0;
    }

    public void TakeWater(){
        if(m_isWet) return;
        m_isWet = true;

    // TODO sprite mouillé
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public void Seed(){ // TODO param plant
        if(m_plant != null) return;

        m_plant = "plant";
        m_days = 1;

    // TODO graines dans le sol
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void Harvest(){
        // TODO create object plant
        if(m_days < 1) return; // TODO remplace 1 par nb jours de maturation de l'objet plant

        m_plant = null;
        m_days = 0;

    // TODO supprimer sprite plante
        GetComponent<SpriteRenderer>().color = Color.blue;

        // TODO return plant -> le joueur récupère l'objet
        // TODO faire un diagramme d'interaction
    }
}
