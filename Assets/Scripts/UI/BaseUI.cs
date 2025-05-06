using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public virtual void Open() {
        gameObject.SetActive(true);
    }

    public virtual void Close() {
        gameObject.SetActive(false);
    }
}
