using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // textmeshpro nun k�t�phanesi.

public class sepet : MonoBehaviour
{
    public ParticleSystem partik�ller;

    public int skor = 0;

    public float hiz;

    public TextMeshProUGUI skor_txt; //textmeshprougu� t�r�nde bir de�i�ken belirledik. // e�er bu de�i�keni public olarak tn�mlarsam unity �zerinden s�r�kle b�rak ile de atama yapabilirim.

    public AudioSource ses_dosyasi;

    public AudioClip pat_sesi;

    void Start()
    {
        // skor_txt = GameObject.Find("Canvas/skor_txt").GetComponent<TextMeshProUGUI>(); //textmeshprougu� bile�enini de�i�kene atad�k. // de�i�keni public yaparsam burda atama yapmama gerek kalmaz.

        partik�ller.Stop();

        //Application.Quit(); // oyundan ��kmaya yarar start�n i�ine yaz�lmak zorunda de�il ben oraya yazd�m sadece. oyunnun render�n� almad���m�z i�in bu kod �al��mayacak.
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

            partik�ller.Play();

            skor_txt.text = skor.ToString(); //skor de�i�kenini string e d�n��t�r�p textmeshprougu� nin textine atad�k.  

            Destroy(collision.gameObject);


        }


    }

  
}

