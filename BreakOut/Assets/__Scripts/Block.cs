using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //esta clase sera nuestro bloque base
    //de aqui heredaran las demas clases de bloque
    //podremos aprender acerca de herencia, polimorfismo
    //sobrecarga de metodos, etc.

    //cantidad de golpes que podra resistir el bloque antes de ser destruido
    public int resistencia = 1;
    

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
            resistencia--;
        }
    }

    private void Update()
    {
        if (resistencia <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
