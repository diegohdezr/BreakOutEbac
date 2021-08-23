using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            //calculamos el angulo en el que entro la colision
            Vector3 direccion = collision.contacts[0].point - transform.position;
            //una vez calculada la colision se normaliza para dejar su magnitud en 1
            direccion = direccion.normalized;
            //obtenemos la velocidad definida en la bola y aplicamos esa magnitud a nuestra direccion
            collision.rigidbody.velocity = collision.gameObject.GetComponent<Ball>().ballVelocity * direccion;
            //reducimos la resistencia de nuestro bloque
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get the current screen position from the input class
        Vector3 mousePos2D = Input.mousePosition;

        //the camer's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;


        //conver the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of this basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
}
