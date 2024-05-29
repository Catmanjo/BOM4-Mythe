using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private string NewGameLevel = "Main";
    [SerializeField] GameObject pos1;
    [SerializeField] GameObject LoadingScreen;
    Vector3 velocity;
    float speed = 300;
    bool slide = false;
    public void NewGameButton()
    {
        slider();
    }

    public void slider()
    {
        slide = true;
    }

    private void Update()
    {
        if (slide)
        {
            Vector3 diff;
            diff = pos1.transform.position - LoadingScreen.transform.position;
            LoadingScreen.transform.position += diff.normalized * speed * Time.deltaTime;
            if (LoadingScreen.transform.position.y <= pos1.transform.position.y)
            {
                Debug.Log("newScene");
                SceneManager.LoadScene(NewGameLevel);
               
            }
        }
    }
    
}
