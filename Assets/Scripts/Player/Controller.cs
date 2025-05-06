using UnityEngine;

public class Controller : MonoBehaviour
{
    private PlayerInputs _controls;
    private PlayerMovement _movement;
    private Vector2 _moveInput;

    void Awake(){
        _controls = new PlayerInputs();
        _movement = GetComponent<PlayerMovement>();

        _controls.Player.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => _moveInput = Vector2.zero;
    } 

    void FixedUpdate(){
        _movement.Move(_moveInput);
    }

    void OnEnable(){
        _controls.Player.Enable();
    }
    void OnDisable(){
        _controls.Player.Disable();
    }
}
