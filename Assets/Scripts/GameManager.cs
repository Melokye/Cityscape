using UnityEngine;

public class GameManager : MonoBehaviour
{
    // TODO private ?
    public static GameManager instance; 
    public ItemManager itemManager;

    private void Awake(){
        if(instance != null && instance != this){
            Destroy(instance);
        }else{
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        itemManager = GetComponent<ItemManager>();
    }
}
