using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrollLevels : MonoBehaviour
{
    bool Up = false;
    bool Down = false;
    bool Right = false;
    bool Left = false;

    [SerializeField] Vector3 moveDirection;
    public Vector3 cube;

    public InterstitialAds ad;

    public GameObject firstPart;
    public GameObject secondPart;

    private void FixedUpdate()
    {
        if (Up == true)
        {
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }

        if (Down == true)
        {
            GetComponent<Rigidbody>().velocity += moveDirection;
        }

        if (Right == true)
        {
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }

        if (Left == true)
        {
            GetComponent<Rigidbody>().velocity += moveDirection;
        }
    }

    public void moveUp(bool _Up)
    {
        Up = _Up;
    }

    public void moveDown(bool _Down)
    {
        Down = _Down;
    }

    public void moveLeft(bool _Left)
    {
        Left = _Left;
    }

    public void moveRight(bool _Right)
    {
        Right = _Right;
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

        else if(this.CompareTag("Player") && other.CompareTag("TrollFinish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (this.CompareTag("Player") && other.CompareTag("LastLevel"))
        {
            SceneManager.LoadScene("Menu");
            ad.ShowAd();
        }
    }
}
