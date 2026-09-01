using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input System")]
    [SerializeField] 
    private InputActionReference movement;

    [Header("Movement Values")]
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float acceleration = 70f;
    [SerializeField] private float deceleration = 80f;

    [Header("Step Sounds")]
    [SerializeField] float stepTimer = 1f;
    [SerializeField] float stepTimerMax = 0.5f;
    [SerializeField] AudioClip[] steps;
    [SerializeField] AudioSource stepSource;
    
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stepSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Walking();
    }

    void Walking()
    {
        //Obtain movement values through the movement input action which provides a Vector2
        Vector2 movementVector = movement.action.ReadValue<Vector2>();
        //Apply speed(scalar) to the movement vector
        Vector2 targetVelocity = maxSpeed * movementVector;
        //If the player is moving decide whether or not to apply acceleration or deceleration
        float accelerationRate = (targetVelocity.magnitude > 0.01f) ? acceleration : deceleration;
        //Apply velocity
        rb.linearVelocity = Vector2.MoveTowards(rb.linearVelocity, targetVelocity, accelerationRate * Time.deltaTime);

        // If you are walking, trigger the steps function
        if (accelerationRate == acceleration)
            StepTrigger();
        
    }

    void StepTrigger()
    {
        stepTimer += Time.deltaTime;
        if (stepTimer > stepTimerMax)
        {
            int randomStep = Random.Range(0, steps.Length);
            stepSource.clip = steps[randomStep];
            stepSource.Play();
            stepTimer = 0;
        }
    }

}
