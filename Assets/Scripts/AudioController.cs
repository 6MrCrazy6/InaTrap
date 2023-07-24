using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource music;
    public Slider slider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Volume")) music.volume = 1f;
    }

    void Update()
    {
        music.volume = PlayerPrefs.GetFloat("Volume");
    }

   
}
