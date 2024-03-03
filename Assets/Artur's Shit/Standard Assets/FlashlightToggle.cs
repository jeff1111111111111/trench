using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO; //light gameObject to work with
    private bool isOn = false; //is flashlight on or off?
    [SerializeField] private AudioClip m_FlashlightOnSound;
    [SerializeField] private AudioClip m_FlashlightOffSound;
    private AudioSource m_AudioSource;

    [Header("Battery UI Parameters")]
    [SerializeField] private Image batteryProgressUI = null;

    [Header("Battery Drain Parameters")]
    [Range(0, 50)] [SerializeField] private float batteryDrain = 0.5f;

    [Header("Battery Main Parameters")]
    public int difficulty = 1;
    public float batteryLife = 100.0f;
    [SerializeField] private float maxBatteryLife = 100.0f;


    // Use this for initialization
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        //set default off
        lightGO.SetActive(isOn);
    }

    // Update is called once per frame
    void Update()
    {
        //toggle flashlight on key down
        if (Input.GetKeyDown(KeyCode.X))
        {
            //toggle light
            isOn = !isOn;
            //turn light on
            if (isOn && batteryLife > 0)
            {
                StartCoroutine(LoseBattery());
                lightGO.SetActive(true);
                m_AudioSource.clip = m_FlashlightOnSound;
                m_AudioSource.Play();
            }
            //turn light off
            else
            {
                StopCoroutine(LoseBattery());
                lightGO.SetActive(false);
                m_AudioSource.clip = m_FlashlightOffSound;
                m_AudioSource.Play();
            }
        }
    }
    IEnumerator LoseBattery()
    {
        while (batteryLife > 0 && isOn)
        {
            batteryLife -= 1f * difficulty;
            UpdateBattery();
            //float newValue = (batteryLife - maxBatteryLife) * -1;
            //percent = newValue / maxBatteryLife;
            //vignette.intensity.value = percent;
            yield return null;
        }
    }
    public void UpdateBattery()
    {
        batteryProgressUI.fillAmount = batteryLife / maxBatteryLife;
        if (batteryLife == 0)
        {
            isOn = false;
            StopCoroutine(LoseBattery());
            lightGO.SetActive(false);
            m_AudioSource.clip = m_FlashlightOffSound;
            m_AudioSource.Play();
        }
    }
    public void AffectBattery(float value)
    {
        batteryLife += value;
        if(batteryLife > maxBatteryLife)
        {
            batteryLife = maxBatteryLife;
        }
        
    }
}
