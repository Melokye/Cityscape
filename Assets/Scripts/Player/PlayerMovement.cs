using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    // Public variables
    public Animator animator; // TODO private
    
    // TODO à garder ?
    public Transform actionPoint;
    public float actionRange = 0.5f;
    public LayerMask soilLayers; // TODO à déplacer ?

    private Rigidbody2D _rigidBody;
    private Vector2 _direction;
    private float _speed = 5f; // The speed at which the player moves

    void Start(){
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
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

    public void Move(Vector2 aDirection){
        // Apply movement to the player in FixedUpdate for physics consistency
        _rigidBody.linearVelocity = aDirection * _speed;
        _direction = aDirection;
    }

    void AnimateMovement(){
        if(animator == null){ return; }

        // TODO supp _direction ?
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
}
