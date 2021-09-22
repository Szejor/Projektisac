using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public GameObject Projectile;

    Vector3 lastDirection;
    float shootInterval, lastShot;
    // Start is called before the first frame update
    void Start()
    {
        lastDirection = Vector3.down;
        shootInterval = 1f;
        lastShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lastDirection = Vector3.down;
    }

    private void FixedUpdate()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(xMovement, yMovement, 0);

        movement.Normalize();


        if (movement.magnitude > 0)
        {
            transform.Translate(movement * Time.deltaTime * speed);
            lastDirection = movement;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (lastShot <= 0)
        {
            GameObject p = Instantiate(Projectile, transform.position, Quaternion.identity);
            p.GetComponent<Rigidbody2D>().AddForce(lastDirection * 1000);
            Destroy(p, 3);
            lastShot = shootInterval;
        }
        else
        {
            lastShot -= Time.deltaTime;
        }
    }
}