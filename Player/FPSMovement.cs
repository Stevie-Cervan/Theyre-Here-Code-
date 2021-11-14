using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{

    public Rigidbody rb;
    [SerializeField] float speed;

    // Sprinting
    [SerializeField] float speedMultiplier = 1.5f;

    //Captured
    public bool isCaptured;
    
    //Animations
    public Animator cameraAnimator;

    //Audio Source
    public AudioSource audioSourceRunning;
    public AudioSource audioSourceBreathing;
    public AudioSource audioSourceHorrorStinger;
    public bool isRunning;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isCaptured = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCaptured == false){
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 moveBy = transform.right * x + transform.forward * z;
            rb.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);
            cameraAnimator.SetBool("isRunning", false);

            //Sprinting
            float actualSpeed = speed;
            if(Input.GetKey(KeyCode.LeftShift)){
                actualSpeed *= speedMultiplier;
                cameraAnimator.SetBool("isRunning", true);
                isRunning = true;
            }
            else{
                isRunning = false;
            }

            rb.MovePosition(transform.position + moveBy.normalized * actualSpeed * Time.deltaTime);
        }
        else{
            Debug.Log("Can Not Move! You've been captured!");
            cameraAnimator.SetBool("isRunning", false);
            isRunning = false;  
            audioSourceBreathing.volume = 0;
            audioSourceBreathing.Stop();
        }

        if(isRunning == true){
            audioSourceRunning.volume = 1;
        }
        else{
            audioSourceRunning.volume = 0;
        }
            
    }
}
