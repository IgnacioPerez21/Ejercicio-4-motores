using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40f;
    public GameObject projectilePrefab; // Referencia al prefab del proyectil

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" seg�n tu configuraci�n de entrada
        {
            // Llama a la funci�n para lanzar el proyectil
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        // Instancia el prefab del proyectil en la posici�n y rotaci�n actual del jugador
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Obt�n el componente Rigidbody2D del proyectil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Aplica fuerza al proyectil en la direcci�n hacia adelante del jugador
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }
}
