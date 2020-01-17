using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Character Attributes:")]
    public float MOVEMENT_BASE_SPEED = 1.0f;
    public static Vector3 startPosition = new Vector3(-12f, -1f, -1f);

    [Space]
    [Header("Character Statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("References:")]
    public Rigidbody2D rigidbody;
    public Animator animator;
    public TrainMovement train;

    public bool isArrived;


    private Vector3 flyingPosition = startPosition + new Vector3(2.0f, 1.0f, 0f);
    private Vector3 landingPosition = startPosition + new Vector3(4.0f, 0f, 0f);

    private float flyingTime = 0.1f;
    private bool isFlying = true;
    private Vector3 flyingSpeed = Vector3.zero;



    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.position = startPosition;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
    }

    void Update()
    { 
        if (isArrived) {
            ProcessInputs();
            Move();
            Animate();
        }
        else {
            if (train.isArrived) {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                if (isFlying) {
                    transform.position = Vector3.SmoothDamp(transform.position, flyingPosition, ref flyingSpeed, flyingTime);
                    if ((flyingPosition.x - transform.position.x) <= 0.001f) {
                        isFlying = false;
                        transform.Rotate(0, 0, -60);
                        Debug.Log("Fly!!");
                    }
                }
                else {
                    transform.position = Vector3.SmoothDamp(transform.position, landingPosition, ref flyingSpeed, flyingTime); 
                    if ((landingPosition.x - transform.position.x) <= 0.001f) {
                        isArrived = true;
                        transform.Rotate(0, 0, 60);
                        gameObject.GetComponent<CircleCollider2D>().enabled = true;
                        transform.GetComponent<Animator>().enabled = true;
                        Debug.Log("Land!!");
                    }
                }
            }
        }
    }

    void ProcessInputs() {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void Move() {
        rigidbody.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    void Animate() {
        if (movementDirection != Vector2.zero) {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Magnitude", movementSpeed);
    }
}
