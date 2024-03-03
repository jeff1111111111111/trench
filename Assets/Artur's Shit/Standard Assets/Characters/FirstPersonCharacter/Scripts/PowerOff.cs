using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOff : MonoBehaviour
{
    public GameObject[] lights;
    public Collider powerOffTrigger;

    [SerializeField] private AudioClip m_LightsOffSound;
    [SerializeField] private AudioClip m_BangSound;
    private AudioSource m_AudioSource;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_AudioSource.clip = m_BangSound;
            m_AudioSource.Play();
            m_AudioSource.clip = m_LightsOffSound;
            m_AudioSource.Play();
            powerOffTrigger.enabled = false;
            foreach(GameObject go in lights)
            {
                go.SetActive(false);
            }
        }
    }
}
