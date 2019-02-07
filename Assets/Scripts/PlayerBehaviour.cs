using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject textWin;
    private bool menu = false;
    
    void Update()
    {
        //Escape button
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!menu)
            {

            }
            else
            {

            }
            menu = !menu;
        }
    }

    //physics
    void FixedUpdate()
    {
        if (!menu)
        {
            //movement
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
    }
}
