using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Public variables
    public float speed = 5f; // The speed at which the player moves
    // public Animator animator; // TODO insert animation
    public Transform actionPoint;
    public float actionRange = 0.5f;
    public LayerMask soilLayers; // TODO à déplacer ?

    // Private variables 
    private PlayerInputs _controls;
    private Rigidbody2D _rigidBody;     
    private Vector2 _movement;   

    void Awake(){
        _controls = new PlayerInputs();

        // TODO : mettre dans une fonction Move ?
        _controls.Player.Move.performed += ctx => _movement = ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => _movement = Vector2.zero;
    }

    void Start(){
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;     // Prevent the player from rotating // TODO pas nécessaire ?
    }


    void Update(){

        // Rotate the player based on movement direction
        RotatePlayer(_movement.x, _movement.y);

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
        _rigidBody.linearVelocity = _movement * speed;
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

    void OnEnable(){
        _controls.Player.Enable();
    }

    void OnDisable(){
        _controls.Player.Disable();
    }
}
