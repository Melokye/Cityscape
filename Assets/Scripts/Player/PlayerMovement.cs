using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    
    // TODO à garder ? -> Solution temporaire
    [SerializeField] private Transform _actionPoint;
    [SerializeField] private float _actionRange = 0.5f;
    private Vector3 _pointOffset;
    // --- 

    [SerializeField] private Animator _animator;
    private Rigidbody2D _rigidBody;
    private float _speed = 5f; // The speed at which the player moves
    
    void Start(){
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        _pointOffset = _actionPoint.position - transform.position;
    }

    void Update(){
        // TODO : dépend du type d'objet que le joueur tient
        // TODO : utiliser des triggers
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Watering();
        // }else if(Input.GetKeyDown(KeyCode.Keypad1)){
        //     Seed();
        // }else if(Input.GetKeyDown(KeyCode.Keypad2)){
        //     Harvest();
        // }
    }

    public void Move(Vector2 aDirection){
        // Apply movement to the player in FixedUpdate for physics consistency
        _rigidBody.linearVelocity = aDirection * _speed;
        AnimateMovement(aDirection);

        _pointOffset = _actionPoint.position - transform.position;
        _actionPoint.position = transform.position + _pointOffset;
    }

    public Vector2 GetPosition(){
        // return _rigidBody.position;
        return _actionPoint.position;
    }

    void AnimateMovement(Vector2 aDirection){
        if(_animator == null){ return; }

        // TODO alternative possible pour les Set ?
        if(aDirection.magnitude > 0){
            _animator.SetBool("isMoving", true);
            _animator.SetFloat("horizontal", aDirection.x);
            _animator.SetFloat("vertical", aDirection.y);
        }else{
            _animator.SetBool("isMoving", false);
        }
    }

    /*
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
    */

    // trace le périmètre de l'objet, pour du débug
    void OnDrawGizmosSelected(){
        if(_actionPoint == null) return;
        Gizmos.DrawWireSphere(_actionPoint.position, _actionRange);
    }

}
