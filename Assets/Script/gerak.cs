using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerakFox : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D Rb;

    public float speed = 5;
    public float tinggi = 600;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxisRaw("Horizontal"); // Kiri, kanan
        Rb.velocity = new Vector2(speed * horiz, Rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Rb.AddForce(new Vector2(0, tinggi));
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        Destroy(gameObject);
    }
}
