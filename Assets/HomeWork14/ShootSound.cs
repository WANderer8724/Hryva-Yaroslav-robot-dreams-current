using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSound : MonoBehaviour
{
    [SerializeField] AudioSource ShootSource;
    [SerializeField] AudioClip AudioClip;

    public void ShootHandler()
    {
        Debug.Log("Shoot Sound");
        ShootSource.PlayOneShot(AudioClip);
    }




}
