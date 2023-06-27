using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // sahne yönetimi için gerekn küyüphanedir.

public class yonetici : MonoBehaviour
{
    int saniye = 10;

    public GameObject elma;

    float zaman_araligi = 0.8f;

    float kalan_zaman = 0.0f;

    bool oyundurduruldu = false;

    void Start()
    {
      //  Invoke("saniye_azalt", 1.0f); //Belirlenen bir çalýþma zamanýndan sonra, tanýmlanmýþ herhangi bir fonksiyonun 1 kez çalýþmasýný saðlar Invoke("fonksyon", çalýþma zamaný) 

      //  InvokeRepeating("saniye_azalt", 0.0f, 1.0f); // belirli aralýklarla tekrar etmesini istiyorsam bu fonksiyonu kullanýrým.

      //  InvokeRepeating("elma_ekle", 0.0f, 0.5f);
    }

   
    void Update()
    {
        //Debug.Log(Time.time.ToString()); //oyun çalýþmaya baþladýðýnda oyunda geçen süreyi sayan bir zaman sayacý baþlar Time.time bunu ifade eder. 
                                           //tosstring burda yazmak zorunda deðillim ama el alýþsýn falan diye iþte.

       // Time.timeScale = 1.0f; //oyun zamanýn ilerleme kat sayýsý gýbi, 1 olunca zamana bir etkisi olmaz örneðin 0.5 olursa oyunu yarý hýzýnda oynatýr, 0.0 olursa oyun durur. Pause iþlemlerinde kullanýlabilir.

        if (Time.time >= kalan_zaman)
        {
            elma_ekle();

            kalan_zaman = zaman_araligi + Time.time; // oyundaki süreye 0.8 ekler , daha sonra if bloðu sayesinde yarým saniyede bir elma eklenir.

        }   
    }


    void saniye_azalt()
    {
        saniye--;

        //Debug.Log(saniye.ToString());

        if (saniye == 5)
        {
            CancelInvoke("saniye_azalt"); //Ýlgili InvoveRepeating() fonksiyonunun çalýþmasýný durdurur. Parametre olarak bir metod adý almazsa o an çalýþan bütün InvokeRepeating metodlarýný durdurur.
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
       

        SceneManager.LoadScene("Scenes/SampleScene"); //sahneyi en baþtan yüklemek için bu kod kullanýlýr.

        Time.timeScale = 1.0f;
    }

}
