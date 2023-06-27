using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // sahne y�netimi i�in gerekn k�y�phanedir.

public class yonetici : MonoBehaviour
{
    int saniye = 10;

    public GameObject elma;

    float zaman_araligi = 0.8f;

    float kalan_zaman = 0.0f;

    bool oyundurduruldu = false;

    void Start()
    {
      //  Invoke("saniye_azalt", 1.0f); //Belirlenen bir �al��ma zaman�ndan sonra, tan�mlanm�� herhangi bir fonksiyonun 1 kez �al��mas�n� sa�lar Invoke("fonksyon", �al��ma zaman�) 

      //  InvokeRepeating("saniye_azalt", 0.0f, 1.0f); // belirli aral�klarla tekrar etmesini istiyorsam bu fonksiyonu kullan�r�m.

      //  InvokeRepeating("elma_ekle", 0.0f, 0.5f);
    }

   
    void Update()
    {
        //Debug.Log(Time.time.ToString()); //oyun �al��maya ba�lad���nda oyunda ge�en s�reyi sayan bir zaman sayac� ba�lar Time.time bunu ifade eder. 
                                           //tosstring burda yazmak zorunda de�illim ama el al��s�n falan diye i�te.

       // Time.timeScale = 1.0f; //oyun zaman�n ilerleme kat say�s� g�bi, 1 olunca zamana bir etkisi olmaz �rne�in 0.5 olursa oyunu yar� h�z�nda oynat�r, 0.0 olursa oyun durur. Pause i�lemlerinde kullan�labilir.

        if (Time.time >= kalan_zaman)
        {
            elma_ekle();

            kalan_zaman = zaman_araligi + Time.time; // oyundaki s�reye 0.8 ekler , daha sonra if blo�u sayesinde yar�m saniyede bir elma eklenir.

        }   
    }


    void saniye_azalt()
    {
        saniye--;

        //Debug.Log(saniye.ToString());

        if (saniye == 5)
        {
            CancelInvoke("saniye_azalt"); //�lgili InvoveRepeating() fonksiyonunun �al��mas�n� durdurur. Parametre olarak bir metod ad� almazsa o an �al��an b�t�n InvokeRepeating metodlar�n� durdurur.
        }
       
        
    }


    void elma_ekle()
    {
        float rast = Random.Range(-8.00f, 8.00f);

        GameObject yeni_elma = Instantiate(elma, new Vector3(rast, 8.05f, -9.48f), Quaternion.identity);

    }

    public void pause_btn()
    {
        oyundurduruldu = !oyundurduruldu;

        if (oyundurduruldu == true)
        {
            Time.timeScale = 0.0f;
        }

        else
        {
            Time.timeScale = 1.0f;
        }
    }


    
    public void tekrar_oyna()
    {
       

        SceneManager.LoadScene("Scenes/SampleScene"); //sahneyi en ba�tan y�klemek i�in bu kod kullan�l�r.

        Time.timeScale = 1.0f;
    }

}
