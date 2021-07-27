using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[CreateAssetMenu(menuName = "ScriptableObjects/AudioManager")] //sozdat v menu po pravoi knopke

public class SoundManager : ScriptableObject
{

    [SerializeField] private AudioClip shootClip; //melodii v formate mp3 v etom konteinere
    [SerializeField] private AudioClip sheepHitClip;
    [SerializeField] private AudioClip sheepDropClip;
    
    
    private Vector3 cameraPosition;
    private void PlaySound(AudioClip audioClip) //playsound - metod v kotorom poluchaem audioclip
    {
        cameraPosition = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(audioClip, cameraPosition); // PlayClipAtPoint - funkciz proigrivaet audioClip v pozicii kameri
    }

    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }
    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }
    public void PlayDropClip()
    {
        PlaySound(sheepDropClip);
    }

}
