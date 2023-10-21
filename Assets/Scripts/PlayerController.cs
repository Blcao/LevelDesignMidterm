using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public Camera playerCam;
    public Rigidbody playerBody;

    public GameObject flashLight;
    public bool flashlightOn = false;

    public Vector3 crouchHeight = new Vector3(0, .4f, 0);

    public float speed = 5f;
    public bool sprinting = false;

    public float jumpForce = 7f;

    public float rotationSpeed = 5f;
    public float pitch;
    public float yaw;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        if (Input.GetKey(KeyCode.W))
        {
            Move(transform.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-transform.right);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(-transform.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(transform.right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //rotation
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -90, 90);
        playerCam.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);

        yaw += rotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        //crouch&sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = true;
        } else
        {
            sprinting = false;
        }
        if (Input.GetKey(KeyCode.LeftControl)) {
            playerCam.transform.localPosition = crouchHeight;
            speed = 2.5f;
        } else
        {
            playerCam.transform.localPosition = new Vector3(0, .7f, 0);
            if (sprinting == false)
            {
                speed = 5f;
            } else
            {
                speed = 10f;
            }
        }

        //flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }
    }

    public void Move(Vector3 dir)
    {
        transform.position += speed * dir * Time.deltaTime;
    }

    public void ToggleFlashlight()
    {
        flashlightOn = !flashlightOn;
        flashLight.SetActive(flashlightOn);
    }
}
