using UnityEngine;
using System.Collections.Generic;

public abstract class BaseUIManager : MonoBehaviour
{
    private Stack<BaseUI> _uiStack = new Stack<BaseUI>();

    public virtual void OpenUI(BaseUI ui){
        if (_uiStack.Count > 0) {
            _uiStack.Peek().Close();
        }

        _uiStack.Push(ui);
        ui.Open();
    }

    public virtual void CloseCurrentUI(){
        if (_uiStack.Count == 0) return;

        _uiStack.Pop().Close();

        if (_uiStack.Count > 0){
            _uiStack.Peek().Open();
        }
    }

    public virtual void CloseAllUIs(){
        while (_uiStack.Count > 0) {
            _uiStack.Pop().Close();
        }
    }

    public virtual BaseUI GetCurrentUI(){
        return _uiStack.Count > 0 ? _uiStack.Peek() : null;
    }
}
