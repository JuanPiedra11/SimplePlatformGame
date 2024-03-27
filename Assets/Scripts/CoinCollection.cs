using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    // Start is called before the first frame update

    public int Coin = 0;
    public TextMeshProUGUI coinText;
    public AudioClip coinSound;
    internal GameObject coinCollection;
    public GameObject CamaraRef;
  
    

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.transform.tag == ("coin")) {

            //AudioSource.PlayClipAtPoint(coinSound, transform.position,0.5f);
            AudioSource.PlayClipAtPoint(coinSound, CamaraRef.transform.position, 0.5f);
            Coin ++;
            //coinText.text = "Coins: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(other.gameObject);
             
                      
        }
    }



    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {



        coinText.text = Coin.ToString();


    }

}
