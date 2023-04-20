using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField] bool sprint;
    [SerializeField] float hMove;
    [SerializeField] float vMove;
    [SerializeField] float sprintSpeed = 1.5f;
    [SerializeField] float turnSpeed = 20f;
    [SerializeField] Vector3 dir;
    [SerializeField] Quaternion rotation = Quaternion.identity;

    [Header ("Controls & Animations")]
    [SerializeField] bool isHMove = false;
    [SerializeField] bool isVMove = false;
    [SerializeField] bool isWalking = false;

    [Header ("Components")]
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hMove = Input.GetAxis("Horizontal");
        vMove = Input.GetAxis("Vertical");
        sprint = Input.GetKey(KeyCode.LeftShift);

        dir.Set(hMove, 0f, vMove);
        dir.Normalize();

        if (sprint) {
            dir *= sprintSpeed;
        }

        isHMove = !Mathf.Approximately(hMove, 0f);
        isVMove = !Mathf.Approximately(vMove, 0f);
        isWalking = isHMove || isVMove;

        animator.SetBool("isWalking", isWalking);
        if (isWalking) {
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        }
        else {
            audioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, dir, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove() {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            rb.MovePosition(rb.position + dir * animator.deltaPosition.magnitude);
        }
        else {
            float startTime = Time.time;
            rb.velocity = Vector3.Lerp(dir * 1f, Vector3.zero, 
        (Time.time - startTime) * 0.5f);
        }
        
        rb.MoveRotation(rotation);
    }
}
