using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Slot_UI : MonoBehaviour
{
    // TODO récupérable automatiquement ?
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    public void SetItem(Inventory.Slot slot){
        if(slot == null){return;}
        itemIcon.sprite = slot.itemIcon;
        itemIcon.color = new Color(1, 1, 1, 1);
        quantityText.text = slot._count.ToString();
    }

    public void SetEmpty(){
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }
}
