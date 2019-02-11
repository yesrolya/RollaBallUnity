using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    private int score;
    public float speed = 10.0f;
    private Rigidbody rb;
    public Text scoreTab;
    [SerializeField] private GameObject panel;
    [SerializeField] private Button buttonExit;
    [SerializeField] private Button buttonRestart;
    [SerializeField] private GameObject textWin;

    //for instantiating
    public GameObject prefab;
    public int quantity = 20;
    public float radius = 7f;
    private string tag = "Cube";

    private bool menu;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        buttonExit.onClick.AddListener(() => Application.Quit());
        buttonRestart.onClick.AddListener(() => Restart());
        Restart();
    }


    
    void Restart()
    {
        //destroy all pickups
        var cubes = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
        //to game scene with 0' score and at start position
        score = 0;
        menu = false;
        panel.SetActive(menu);
        textWin.SetActive(false);
        scoreTab.text = "Score: " + score;
        transform.position = new Vector3(0f, 0.5f, 0f);
        //create new pickups
        float angle = 2 * 3.14159f / quantity;
        for (int i = 0; i < quantity; i++)
        {
            Vector3 position = new Vector3(radius * Mathf.Sin(angle * i), 0.75f, radius * Mathf.Cos(angle * i));
            Instantiate(prefab, position, Quaternion.identity);
        }
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

    private void OnTriggerEnter(Collider other)
    {
        score++;
        scoreTab.text = "Score: " + score;
        Destroy(other.gameObject);
        if (score == quantity)
            YouWon();
    }

    void YouWon()
    {
        menu = true;
        panel.SetActive(menu);
        textWin.SetActive(true);
    }
}
