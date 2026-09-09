using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input System")]
    [SerializeField]
    public InputActionReference movement;

    [Header("Movement Values")]
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float acceleration = 70f;
    [SerializeField] private float deceleration = 80f;

    [Header("Step Sounds")]
    [SerializeField] float stepTimer = 1f;
    [SerializeField] float stepTimerMax = 0.5f;
    [SerializeField] AudioClip[] steps;
    [SerializeField] AudioSource stepSource;

    [Header("Animation")]
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sr;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stepSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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



        // If you are walking, trigger the steps function and walk anim
        if (accelerationRate == acceleration)
        {
            StepTrigger();
            anim.SetTrigger("Walk");
        }
        else
        {
            anim.SetTrigger("StopWalk");
        }

        // Decide
        if (movement.action.ReadValue<Vector2>().x > 0)
        {
            sr.flipX = true;
        }
        else if (movement.action.ReadValue<Vector2>().x < 0)
        {
            sr.flipX = false;
        }



    }

    void StepTrigger()
    {
        stepTimer += Time.deltaTime;
        if (stepTimer > stepTimerMax)
        {
            int randomStep = Random.Range(0, steps.Length);
            stepSource.pitch = UnityEngine.Random.Range(0.8f, 1.1f);
            stepSource.PlayOneShot(steps[randomStep]);
            stepTimer = 0;
        }
    }

}
