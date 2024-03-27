using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attackLogic : MonoBehaviour
{

    
    public Animator jugadorAnim;
    public PlayerController jugadorScript;

    public GameObject colliderAtaque;

    bool puedeAtacar;


    // Start is called before the first frame update
    void Start()
    {
        puedeAtacar = true;
        
            

    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetButtonDown("Fire1") && jugadorScript.grounded == true && puedeAtacar)
        {
            jugadorAnim.SetTrigger("attack");
            }

    }


    public void ataca() {

        jugadorScript.canMove=false;
        colliderAtaque.SetActive(true);
        puedeAtacar = false;

    
    }


    public void dejaDeAtacar() {
        jugadorScript.canMove = true;
        colliderAtaque.SetActive(false);
        puedeAtacar = true;
    
    
    
    
    }
}
