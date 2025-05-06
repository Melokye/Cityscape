using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    // TODO récupérer directement les enfants
    [SerializeField] private Inventory_UI _inventory;

    private Stack<BaseUI> _uiStack = new Stack<BaseUI>();

    private void Awake(){
        if (instance != null && instance != this){
            Destroy(gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ToggleInventory(){
        if(_uiStack.Count > 0 && _uiStack.Peek() == _inventory){
            CloseCurrentUI();
        }else{
            OpenUI(_inventory);
        }
    }

    public void OpenUI(BaseUI ui){
        if (_uiStack.Count > 0) {
            _uiStack.Peek().Close();
        }

        _uiStack.Push(ui);
        ui.Open();
    }

    public void CloseCurrentUI(){
        if (_uiStack.Count == 0) return;

        _uiStack.Pop().Close();

        if (_uiStack.Count > 0){
            _uiStack.Peek().Open();
        }
    }

    public void CloseAllUIs(){
        while (_uiStack.Count > 0) {
            _uiStack.Pop().Close();
        }
    }
    
}
