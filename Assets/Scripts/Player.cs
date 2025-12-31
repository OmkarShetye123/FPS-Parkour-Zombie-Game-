using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public Camera cam;

    public CharacterController controller;

    public Animator gunAnim;

    public List<Gun> guns = new List<Gun>();

    public float speed = 5f;
    public float rotationSpeed = 200f;
    public float verRot;

    public float jumpHeight;

    Vector3 playerVelocity;

    [Range(0, 100)]
    public int health = 100;

    public int weaponIndex;

    public int kills;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }

    public void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");


        Vector3 dir = transform.right * hor + transform.forward * ver;

        controller.Move(dir * speed * Time.deltaTime);

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * x * rotationSpeed * Time.deltaTime);
        
        verRot -= y * rotationSpeed * Time.deltaTime;
        verRot = Mathf.Clamp(verRot, -75f, 75);
        cam.transform.localRotation = Quaternion.Euler(verRot, 0, 0);

        if (Input.GetKey(KeyCode.Space))
        {
            playerVelocity.y = Mathf.Sqrt(2 * 9.8f * jumpHeight);
        }
        if (controller.isGrounded)
        {
            playerVelocity.y = -.2f;
        }

        playerVelocity.y += (-9.8f) * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            guns[0].Shoot();
        }

        GameManager.instance.healthBar.value = health;

        gunAnim.SetBool("Shoot", Input.GetMouseButton(0) || Input.GetMouseButton(1));

        if (Input.GetKey(KeyCode.E))
        {
            if (weaponIndex >= 3) return;
            weaponIndex++;
            foreach (var item in guns)
            {
                item.gameObject.SetActive(false);
            }
            guns[weaponIndex].gameObject.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.Q)) 
        {
            if (weaponIndex <= 0) return;
            weaponIndex--;
            foreach (var item in guns)
            {
                item.gameObject.SetActive(false);
            }
            guns[weaponIndex].gameObject.SetActive(true);

        }
        if (health <= 0) GameManager.instance.GameOver(false);
    }

}


