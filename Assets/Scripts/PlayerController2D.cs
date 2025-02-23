using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // Public variables
    public float speed = 5f; // The speed at which the player moves
    // public Animator animator;
    public Transform actionPoint;
    public float actionRange = 0.5f;
    public LayerMask soilLayers;

    // Private variables 
    private Rigidbody2D rb; // Reference to the Rigidbody2D component attached to the player
    private Vector2 movement; // Stores the direction of player movement

    void Start()
    {
        // Initialize the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        // Prevent the player from rotating
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
    // TODO : mettre dans une fonction Move ---
    // TODO : utiliser des Action à la place
        // Get player input from keyboard or controller
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Set movement direction based on input
        movement = new Vector2(horizontalInput, verticalInput);
        // Optionally rotate the player based on movement direction
        RotatePlayer(horizontalInput, verticalInput);
    // ---

        if(Input.GetKeyDown(KeyCode.Space)){
            // TODO : dépend du type d'objet que le joueur tient
            Watering();
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the player in FixedUpdate for physics consistency
        rb.linearVelocity = movement * speed;
    }

    void RotatePlayer(float x, float y)
    {
        // If there is no input, do not rotate the player
        if (x == 0 && y == 0) return;

        // Calculate the rotation angle based on input direction
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        // Apply the rotation to the player
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Watering(){
    // TODO animation
        // animator.SetTrigger("Watering");  

    // TODO objects in the range
        Collider2D[] soilsWatering = Physics2D.OverlapCircleAll(actionPoint.position, actionRange, soilLayers);
        // TODO équivalent 3D à appliquer pour Cubi : Physics.OverlapSphere()

    // TODO réaliser l'action
        foreach(Collider2D soil in soilsWatering){
            soil.GetComponent<Soil>().TakeWater();
            Debug.Log("Watering " + soil.gameObject.name); // utiliser un booléen
        }
    }

    // trace le périmètre de l'objet, pour du débug
    void OnDrawGizmosSelected(){
        if(actionPoint == null) return;
        Gizmos.DrawWireSphere(actionPoint.position, actionRange);
    }
}
