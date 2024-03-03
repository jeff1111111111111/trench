using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    public AudioClip paperFx;
    public AudioClip validFx;
    public AudioClip invalidFx;
    public AudioClip doorCodeFx;
    public AudioClip screamFx;
    public AudioClip powerFx;
    public AudioClip doorOpenFx;
    public AudioClip eatPillsFx;
    public AudioClip swallowFx;



    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }
    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }
    public void PickPaper()
    {
        myFx.PlayOneShot(paperFx);
    }
    public void ValidCode()
    {
        myFx.PlayOneShot(validFx);
    }
    public void InvalidCode()
    {
        myFx.PlayOneShot(invalidFx);
    }
    public void JumpScare()
    {
        myFx.PlayOneShot(screamFx);
    }
    public void DoorCode()
    {
        myFx.PlayOneShot(doorCodeFx);
    }
    public void PowerOn()
    {
        myFx.PlayOneShot(powerFx);
    }
    public void OpenDoor()
    {
        myFx.PlayOneShot(doorOpenFx);
    }
    public void EatPills()
    {
        myFx.PlayOneShot(eatPillsFx);
    }
    public void Swallow()
    {
        myFx.PlayOneShot(swallowFx);
    }
}
