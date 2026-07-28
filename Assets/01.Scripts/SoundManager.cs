using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioSource BGMsource;
    [SerializeField] AudioSource SFXsource;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

    }

    public void SetBGMVolume(float volume)
    {
        BGMsource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        SFXsource.volume=volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

}
