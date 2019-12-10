using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : Singleton<SoundHandler>
{
    public AudioSource hitSounds, music;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HitSound() { hitSounds.Play(); }
}
