using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40f;
    public GameObject projectilePrefab; // Referencia al prefab del proyectil
    public float projectileSpeed = 30f;
    public float projectileDestroyDelay = 3f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1") || (Input.GetButtonDown("Jump"))) // Cambia "Fire1" seg�n tu configuraci�n de entrada
        {
            // Llama a la funci�n para lanzar el proyectil
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        // Instancia el prefab del proyectil en la posici�n y rotaci�n actual del jugador
        GameObject projectileObject = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Obt�n el componente Rigidbody2D del proyectil
        Rigidbody2D rb = projectileObject.GetComponent<Rigidbody2D>();

        // Asigna la velocidad al proyectil
        rb.velocity = transform.up * projectileSpeed;

        // Destruye el proyectil despu�s de un tiempo
        Destroy(projectileObject, projectileDestroyDelay);
    }
}