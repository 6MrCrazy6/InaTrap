using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
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

    private int currentLevel;

    private void FixedUpdate()
    {
       if(Up == true)
       {
          GetComponent<Rigidbody>().velocity -= moveDirection;
       }

       if (Down == true)
       {
          GetComponent<Rigidbody>().velocity += moveDirection;
       }

       if(Right == true)
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
            UnlockLevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (this.CompareTag("Player") && other.CompareTag("LastLevel"))
        {
            SceneManager.LoadScene("Menu");
            ad.ShowAd();
        }

        else if (this.CompareTag("Player") && other.CompareTag("Second Part"))
        {
            currentLevel = PlayerPrefs.GetInt("Levels");

            if (currentLevel == 13)
            {
                firstPart.SetActive(false);
                secondPart.SetActive(true);
                cube = this.transform.position;
                cube = cube + new Vector3(-15, 0, -15);
                this.transform.position = cube;
            }
            
            else if(currentLevel == 14)
            {
                firstPart.SetActive(false);
                secondPart.SetActive(true);
                cube = this.transform.position;
                cube = cube + new Vector3(-5, 0, -15);
                this.transform.position = cube;
            }

            else if(currentLevel == 15)
            {
                firstPart.SetActive(false);
                secondPart.SetActive(true);
                cube = this.transform.position;
                cube = cube + new Vector3(-37, 0, -15);
                this.transform.position = cube;
            }

            else if (currentLevel == 16)
            {
                firstPart.SetActive(false);
                secondPart.SetActive(true);
                cube = this.transform.position;
                cube = cube + new Vector3(-22, 0, 3);
                this.transform.position = cube;
            }
        }
    }

    public void UnlockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("Levels"))
        {
            PlayerPrefs.SetInt("Levels", currentLevel);
        }
    }
}
