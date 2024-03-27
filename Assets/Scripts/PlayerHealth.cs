using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float fullHealth;
    float currentHealth;
    public GameObject PleayerDeathFX;
    public TextMeshProUGUI lifeText;

    public AudioClip hurtSound;

    public Text endGameText;
    public restartGame theGameController;
    public GameObject cameraMainref;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = currentHealth.ToString();
    }


    public void addDamage(float damage) {

        //AudioSource.PlayClipAtPoint(hurtSound, transform.position, 0.6f);

        AudioSource.PlayClipAtPoint(hurtSound, cameraMainref.transform.position,0.5f);
        currentHealth -= damage;
        
        if (currentHealth <= 0) {
            lifeText.text = "0";    
            makeDead();
        }

    
    }

    public void makeDead() {
        Instantiate(PleayerDeathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);

        //theGameController.restartTheGame();
        theGameController.LoseTheGame();
        
        

    }

    public void makeWin() { 
        Debug.Log("ganaste el juego");
        theGameController.WinGame();
       
    }
}
