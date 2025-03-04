using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // Public variables
    public float speed = 5f; // The speed at which the player moves
    // public Animator animator; // TODO insert animation
    public Transform actionPoint;
    public float actionRange = 0.5f;
    public LayerMask soilLayers;

    // Private variables 
    private Rigidbody2D rb;     // Reference to the Rigidbody2D component attached to the player
    private Vector2 movement;   // Stores the direction of player movement

    void Start(){
        rb = GetComponent<Rigidbody2D>();                           // Initialize the Rigidbody2D component
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;     // Prevent the player from rotating
    }

    void Update(){
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

        // TODO : dépend du type d'objet que le joueur tient
        // TODO : utiliser des triggers
        if(Input.GetKeyDown(KeyCode.Space)){
            Watering();
        }else if(Input.GetKeyDown(KeyCode.Keypad1)){
            Seed();
        }else if(Input.GetKeyDown(KeyCode.Keypad2)){
            Harvest();
        }
    }

    void FixedUpdate(){
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

    void Watering(){ // TODO fonction abstraite -> Action
    // TODO animation
        // animator.SetTrigger("Watering");  

        Collider2D[] soilsWatering = Physics2D.OverlapCircleAll(actionPoint.position, actionRange, soilLayers);

        foreach(Collider2D soil in soilsWatering){
            soil.GetComponent<Soil>().TakeWater();
            Debug.Log("Watering " + soil.gameObject.name);
        }
    }

    void Seed(){ // TODO fonction abstraite -> Action, à supp après
        // TODO animation
            // animator.SetTrigger("Watering");  

            Collider2D[] soils = Physics2D.OverlapCircleAll(actionPoint.position, actionRange, soilLayers);

            foreach(Collider2D soil in soils){
                soil.GetComponent<Soil>().Seed();
            }
    }

    void Harvest(){ // TODO fonction abstraite -> Action, à supp après
        // TODO animation
            // animator.SetTrigger("Watering");  

            Collider2D[] soils = Physics2D.OverlapCircleAll(actionPoint.position, actionRange, soilLayers);

            foreach(Collider2D soil in soils){
                soil.GetComponent<Soil>().Harvest();
            }
    }

    // trace le périmètre de l'objet, pour du débug
    void OnDrawGizmosSelected(){
        if(actionPoint == null) return;
        Gizmos.DrawWireSphere(actionPoint.position, actionRange);
    }
}
