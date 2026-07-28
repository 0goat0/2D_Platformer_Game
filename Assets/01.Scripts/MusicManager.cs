using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public Slider bgmSlider;

    //private void Awake()
    //{
    //    if (instance == null)
    //        instance = this;
    //    else
    //        Destroy(gameObject);
    //    DontDestroyOnLoad(gameObject);
    //}
    void Start()
    {
        bgmSlider.onValueChanged.AddListener(BGMVolumeChanged);
    }


    public void BGMVolumeChanged(float vol)
    {
        SoundManager.instance.SetBGMVolume(vol);
    }
    public void SFXVolumeChanged(float vol)
    {
        SoundManager.instance.SetSFXVolume(vol);
    }
}
