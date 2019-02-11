using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject textWin;

    private bool menu;
    private void Start()
    {
        menu = false;
        //GetComponent<Rigidbody>().freezeRotation = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Escape button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu = !menu;
            panel.SetActive(menu);
            Debug.Log(menu);
        }
    }

    //physics
    void FixedUpdate()
    {
        if (!menu)
        {
            //movement
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
            rb.AddForce(movement * speed);
        }
    }
}
