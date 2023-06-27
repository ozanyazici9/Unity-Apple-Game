using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // textmeshpro nun kütüphanesi.

public class sepet : MonoBehaviour
{
    public ParticleSystem partiküller;

    public int skor = 0;

    public float hiz;

    public TextMeshProUGUI skor_txt; //textmeshprouguý türünde bir deðiþken belirledik. // eðer bu deðiþkeni public olarak tnýmlarsam unity üzerinden sürükle býrak ile de atama yapabilirim.

    public AudioSource ses_dosyasi;

    public AudioClip pat_sesi;

    void Start()
    {
        // skor_txt = GameObject.Find("Canvas/skor_txt").GetComponent<TextMeshProUGUI>(); //textmeshprouguý bileþenini deðiþkene atadýk. // deðiþkeni public yaparsam burda atama yapmama gerek kalmaz.

        partiküller.Stop();

        //Application.Quit(); // oyundan çýkmaya yarar startýn içine yazýlmak zorunda deðil ben oraya yazdým sadece. oyunnun renderýný almadýðýmýz için bu kod çalýþmayacak.
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(hiz * Time.deltaTime, 0, 0);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-hiz * Time.deltaTime, 0, 0);
        }
         
       
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "elma")
        {
            ses_dosyasi.PlayOneShot(pat_sesi, 0.5f);

            skor += 10;

            Debug.Log(skor.ToString());

            partiküller.Play();

            skor_txt.text = skor.ToString(); //skor deðiþkenini string e dönüþtürüp textmeshprouguý nin textine atadýk.  

            Destroy(collision.gameObject);


        }


    }

  
}

