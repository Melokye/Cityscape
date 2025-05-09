using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap; // TODO rename _interactableMap

    void Start()
    {
        foreach (Vector3Int pos in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(pos);
            if (tile != null)
            {
                Debug.Log(tile.name + " at " + pos);
            }
        }
    }

    public bool IsInteractable(Vector2 aPosition, Vector2 aDirection){
        // Vector3Int conversion = interactableMap.WorldToCell(new Vector3(aPosition.x, aPosition.y, 0));
        // conversion += new Vector3Int((int) aDirection.x, (int) aDirection.y, 0);

        // TileBase tile = interactableMap.GetTile(conversion);
        // Debug.Log(conversion);
        // return tile != null; //&& tile.name == "Pots";

        Collider2D[] hits = Physics2D.OverlapCircleAll(aPosition, 0.5f); 
            // TODO 0.5 -> _actionRange, PlayerMovement.cs
 
        foreach (var hit in hits){
            if(hit.gameObject.name == "Pots"){
                // TODO name en param ?
                return true;
            }
            // Debug.Log("Objet détecté : " + hit.gameObject.name);
        }
        
        return false;
        // utiliser SetTile(position, Tile asset) pour le jardin partagé 
    }

}
