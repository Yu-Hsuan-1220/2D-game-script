using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 moveInput;
    private Animator animator; 
    private void Start() {
        animator = GetComponent<Animator>();
    }
    void Update(){  
        if(moveInput.magnitude != 0f){
            animator.SetBool("isRunning", true);
            Vector2 move = moveInput * speed * Time.deltaTime;
            transform.Translate(move.x, move.y, 0);
        }
        else{
            animator.SetBool("isRunning", false);
        }
    }
    
    public void getMoveInput(InputAction.CallbackContext ctx){
        moveInput = ctx.ReadValue<Vector2>();
    }

    
}
