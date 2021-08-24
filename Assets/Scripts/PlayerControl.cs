using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;

    //Movement Variables
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public KeyCode runKey = KeyCode.LeftShift;

    //Look Variables
    public float sensitivity = 1;
    public float smoothing = 2;

    private Transform charCamera;
    private Vector2 currentMouseLook;
    private Vector2 appliedMouseDelta;

    //Jump Variables 
    public float jumpStrength = 5;
    public KeyCode jumpKey = KeyCode.Space;
    private bool isGrounded;

    //Only For Jimmy
    public int jumpMax = 2;
    private int jumps;
    public AudioClip jumpSFX;
    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();

        jumps = jumpMax;
        isGrounded = true;

        //Initializing the mouse and camera
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        charCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Code for Running

        float speed = Input.GetKey(runKey) ? runSpeed : walkSpeed;

        float inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float inputZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rb.transform.Translate(inputX, 0, inputZ);

        //Code for Looking
        Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
        appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
        currentMouseLook += appliedMouseDelta;
        currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);

        charCamera.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);

        //Code for Jumping
        if (Input.GetKeyDown(jumpKey) && jumps > 0)
        {
            rb.AddForce(rb.transform.up * jumpStrength, ForceMode.Impulse);
            source.PlayOneShot(jumpSFX);
            jumps = jumps - 1;
        }

    }

    //Checking for Ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = jumpMax;
            isGrounded = true;
            print("You are currently grounded"); 
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            print("You are not grounded");
        }
    }
}
