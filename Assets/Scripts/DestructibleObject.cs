using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{

    //variables

    public float damagePerPunch;
    public float objectLife;
    float currentOjbectLife;
    public GameObject PunchFx;
    public GameObject Coin;
    private Vector3 originPosition;
    public Transform CheckerCoinsinBox;
    public AudioClip golpebox;
    public AudioClip destruirCaja;
    public GameObject exploteFX;




    

   




    // Start is called before the first frame update
    void Start()

         
    {

        
        originPosition = transform.position;
        //Coin = (GameObject)Instantiate(Coin, originPosition, Quaternion.identity);
        
        





        currentOjbectLife = objectLife;
        

    }


    

   


    // Update is called once per frame
    void Update()
    {

        originPosition = CheckerCoinsinBox.position;

        // if(Coin != null) {     
        // Coin.transform.localPosition = CheckerCoinsinBox.transform.position;
        // }


        if (currentOjbectLife <= 0) {
            Coin = (GameObject)Instantiate(Coin, originPosition, Quaternion.identity);
            AudioSource.PlayClipAtPoint(destruirCaja, transform.position, 1f);
            Instantiate(exploteFX, transform.position, Quaternion.identity);
            Destroy(gameObject);

            
        }






    }

    


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ataqueJugador")) {

            AudioSource.PlayClipAtPoint(golpebox, transform.position, 1f);
            currentOjbectLife -= damagePerPunch;
                Instantiate(PunchFx, other.transform.position, Quaternion.identity);


            //Debug.Log(currentOjbectLife);
        }
    }

  
}
