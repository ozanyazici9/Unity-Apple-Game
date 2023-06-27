using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zemin : MonoBehaviour
{
    float can = 100.0f;

    float guncel_can = 100.0f;

    Image can_bari;

    public GameObject durdur_panel;

    public GameObject elma;

    void Start()
    {
       can_bari =  GameObject.Find("Canvas/siyah_kalp/can_bari").GetComponent<Image>();
    }

    
    void Update()
    {
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "elma")
        { 
            Destroy(collision.gameObject);

            guncel_can -= 10.0f;

            can_bari.fillAmount = guncel_can / can;

        }

        if (guncel_can <= 0)
        {
            Time.timeScale = 0.0f;

            durdur_panel.SetActive(true);

           

        }
    }
}
