using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float movSpeed = 5f;
    private Animator animator;
    private string IS_WALKING = "isWalking";
    public Camera mainCamera;
    public Vector3 moveDir = new Vector3 (0f,0f,0f);
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
    }
    private void Update() {
        HandleMovementInput();
    }

    void HandleMovementInput() {
        float vertical = 0f;
        float horizontal = 0f;

        if (Input.GetKey(KeyCode.W)) {
            vertical = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            vertical = -1;
        }

        if (Input.GetKey(KeyCode.A)) {
            horizontal = -1;
        }

        if (Input.GetKey(KeyCode.D)) {
            horizontal = +1;
        }

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();
        
        moveDir = cameraForward*vertical +cameraRight*horizontal;
        moveDir.Normalize();

        bool canMove = !Physics.Raycast(transform.position, moveDir, .7f);

        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)) {
            animator.SetBool(IS_WALKING, true);
        }
        else {
            animator.SetBool(IS_WALKING, false);
        }
        if (canMove){
            transform.position += moveDir *movSpeed *Time.deltaTime;
        }
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        /*Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }

        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }

        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)) {
            animator.SetBool(IS_WALKING, true);
        }
        else {
            animator.SetBool(IS_WALKING, false);
        }

        

        inputVector = inputVector.normalized;
        moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        bool canMove = !Physics.Raycast(transform.position, moveDir, .7f);
        if (canMove) {
            transform.position += moveDir * Time.deltaTime * movSpeed;
        }
        
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);*/
    }
}
