using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Public variables
    public Animator animator; // TODO insert animation
    public Transform actionPoint;
    public float actionRange = 0.5f;
    public LayerMask soilLayers; // TODO à déplacer ?

    // Private variables 
    private PlayerInputs _controls;
    private Rigidbody2D _rigidBody;
    private Vector2 _direction;
    private float _speed = 5f; // The speed at which the player moves


    void Awake(){
        _controls = new PlayerInputs();

        // TODO : mettre dans une fonction Move ?
        _controls.Player.Move.performed += ctx => _direction = ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => _direction = Vector2.zero;
    }

    void Start(){
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;     // Prevent the player from rotating // TODO pas nécessaire ?
    }


    void Update(){

        AnimateMovement();
        
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
        _rigidBody.linearVelocity = _direction * _speed;
    }

    void AnimateMovement(){
        if(animator == null){ return; }

        if(_direction.magnitude > 0){
            animator.SetBool("isMoving", true);
            animator.SetFloat("horizontal", _direction.x);
            animator.SetFloat("vertical", _direction.y);
        }else{
            animator.SetBool("isMoving", false);
        }
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
