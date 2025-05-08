using UnityEngine;

// TODO rename into GameUIMangager
public class UIManager : BaseUIManager
{
    public static UIManager instance; // TODO a supp 

    // TODO récupérer directement les enfants ?
    [SerializeField] private BaseUI _inventory;
    // TODO [SerializeField] private BaseUI _pauseMenuUI;

    void Awake()
    {
        instance = this;
    }
    void Start(){
        #if UNITY_EDITOR
        DebugTool.CheckSerializeField(this);
        #endif
    }

    public void ToggleInventory(){
        Debug.Assert(_inventory != null, "Le champ '_inventory' n'est pas assigné dans l'inspecteur !");

        if(GetCurrentUI() == _inventory){
            CloseCurrentUI();
        }else{
            OpenUI(_inventory);
        }
    }
}
