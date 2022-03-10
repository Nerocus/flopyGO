using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("���� ���������");
        Application.Quit();
    }
     public void Store()
    {
        SceneManager.LoadScene(2);
    } 
    
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}