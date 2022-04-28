using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    sprint,
    interact,
    menu,
}

public class Player : MonoBehaviour
{
    public PlayerState currentState;
    private Rigidbody2D rigidBody;
    private Animator animator;
    public Vector2Value startingPosition;
    public Vector2Value startingRotation;
    
        //Movement//
    [SerializeField] private float speed;
    [SerializeField] private float sprintSpeed;
    private Vector3 change;

        //Interaction//
    public GameObject thoughtBubble;
    public BoolValue showThoughtBubble;
    public BoolValue interactionOpen;

    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", startingRotation.initialValue.x);
        animator.SetFloat("moveY", startingRotation.initialValue.y);
        transform.position = startingPosition.initialValue;
    }

    void Update()
    {
        //VALUE CHECKS//
        if (showThoughtBubble.initialValue == true) { thoughtBubble.SetActive(true); }
        if (showThoughtBubble.initialValue == false) { thoughtBubble.SetActive(false); }

        //INPUT CHECKS//
        change = Vector3.zero;
        if (currentState != PlayerState.menu && currentState != PlayerState.interact)
        {
            //Movement//
            if (Input.GetButton("Sprint"))
            {
                currentState = PlayerState.sprint;
            }
            else
            {
                currentState = PlayerState.walk;
            }
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            UpdateAnimationAndMove();
        }
    }

    //MOVEMENT//
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        if (currentState == PlayerState.walk)
        {
            rigidBody.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
        }
        if (currentState == PlayerState.sprint)
        {
            rigidBody.MovePosition(transform.position + change * sprintSpeed * Time.fixedDeltaTime);
        }
    }

    //INTERACT//
    public void OpenInteract()
    {
        currentState = PlayerState.interact;
    }
    
    public void CloseInteract()
    {
        currentState = PlayerState.walk;
    }

    //MENU//
    public void OpenMenu()
    {
        animator.SetTrigger("open menu");
        currentState = PlayerState.menu;
        Debug.Log("Open Menu");
    }

    public void CloseMenu()
    {
        animator.SetTrigger("close menu");
        currentState = PlayerState.walk;
        Debug.Log("Close Menu");
    }   
}