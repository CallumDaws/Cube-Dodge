using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    // Start is called before the first frame update
    private static VolumeController instance = null;
    public AudioSource audios;

    private float bgVolume = 1f;

    private void Awake()
    {
        if( instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public static VolumeController Instance
    {
        get { return instance; }
    }
    void Start()
    {
        audios.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audios.volume = bgVolume;   
    }
    public void SetVolume(float vol)
    {
        bgVolume = vol;
    }
}
