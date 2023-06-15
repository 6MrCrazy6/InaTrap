using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection;
    public InterstitialAds ad;

    public void Left()
    {
        GetComponent<Rigidbody>().velocity += moveDirection;
    }

    public void Right()
    {
        GetComponent<Rigidbody>().velocity -= moveDirection;
    }
    public void Down()
    {
        GetComponent<Rigidbody>().velocity += moveDirection;
    }

    public void Up() 
    {
        GetComponent<Rigidbody>().velocity -= moveDirection;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        ad.ShowAd();
    }

    public void RepeatLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (this.CompareTag("Player") && other.CompareTag("LastLevel"))
        {
            SceneManager.LoadScene("Menu");
            ad.ShowAd();
        }
        else if (this.CompareTag("Player") && other.CompareTag("TrollFinish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
