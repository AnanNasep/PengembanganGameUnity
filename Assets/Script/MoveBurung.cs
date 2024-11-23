using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBurung : MonoBehaviour
{
    public int kecepatan, kekuatanLompat;
    public bool balik;
    public int pindah;

    Rigidbody2D lompat;

    //pendetaksi tanah
    public bool tanah;
    public bool lari;
    public LayerMask targetlayer;
    public Transform deteksitanah;
    public float jangkauan;

    Animator anim;
    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        tanah = Physics2D.OverlapCircle(deteksitanah.position, jangkauan, targetlayer);
        if (tanah == false)
        {
            //anim.SetBool("terbang", true);
            //anim.SetBool("lari", false);
        }
        else
        {
            //anim.SetBool("terbang", false);
            //anim.SetBool("lari", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("lar true D");
            anim.SetBool("lari", true);
            lari = true;
            anim.SetBool("diam", false);
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("lar true A");
            anim.SetBool("lari", true);
            lari = true;
            anim.SetBool("diam", false);
            transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            pindah = -1;
        }
        else
        {
            Debug.Log("Menonaktifkan lari");
            anim.SetBool("lari", false);
            lari = false;
            anim.SetBool("diam", true); 
        }

        Debug.Log("Tanah: " + tanah);
        if (tanah == true && (Input.GetKey(KeyCode.Mouse0))) // Tombol kiri mouse
        {
            Debug.Log("Tanah: " + tanah);
            lompat.AddForce(new Vector2(0, kekuatanLompat));
        }
        else
        {
            Debug.Log("Tanah: 2" + tanah);
        }

        if (pindah > 0 && !balik)
        {
            balikBadan();
        }
        else if (pindah < 0 && balik)
        {
            balikBadan();
        }
    } 

    void balikBadan()
    {
        balik = !balik;
        Vector3 karakter = transform.localScale; // fixed typo: trasform to transform
        karakter.x *= -1; // fixed syntax
        transform.localScale = karakter;
    }
}
