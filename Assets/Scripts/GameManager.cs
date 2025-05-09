using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    // TODO : liste de ses enfants, mettre en privé SerializeField ?
    public ItemManager itemManager;
    public TileManager tileManager;


    private void Awake(){
        if(instance != null && instance != this){
            Destroy(instance);
        }else{
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        itemManager = GetComponent<ItemManager>();
        tileManager = GetComponent<TileManager>();
    }

    public void ActiveInteraction(Vector2 aPosition, Vector2 aDirection){
        Debug.Log(aPosition);
         if(tileManager.IsInteractable(aPosition, aDirection)){
            Debug.Log("Boum");
        }
    }
}
