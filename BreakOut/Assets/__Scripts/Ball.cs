using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isGameStarted = false;
    public float ballVelocity = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 initialPosition = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        initialPosition.y += 3;
        this.transform.position = initialPosition;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isGameStarted) 
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = ballVelocity * Vector3.up;
            }
        }
    }
}
