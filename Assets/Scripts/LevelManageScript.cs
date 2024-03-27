using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManageScript : MonoBehaviour
{


    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changueScene() { 
       SceneManager.LoadScene(SceneName);
    
    }
    public void CerrarJuego() { 
    Application.Quit();
    }

}
