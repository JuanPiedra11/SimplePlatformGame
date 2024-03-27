using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{


    public float restartTime;
    bool resetNow = false;
    float resetTime;

   






    // Start is called before the first frame update
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        if (resetNow && resetTime <= Time.time)
        {
            SceneManager.LoadScene(0);
            //Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKey(KeyCode.Escape)) { 
        Application.Quit();
        }
    }

    public void restartTheGame() {
    resetNow = true;
        resetTime = restartTime + Time.time;
    
    }


    public void quitGame() { 
    //Application.Quit();
    }


    public void LoseTheGame() {
        SceneManager.LoadScene("Lose");
        //endPanel.SetActive(true);
        //endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Se acabo el Juego...";
    }

    public void WinGame() {

        SceneManager.LoadScene("Victory");
        //endPanel.SetActive(true);
        //endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Ganaste!";


    }


}
