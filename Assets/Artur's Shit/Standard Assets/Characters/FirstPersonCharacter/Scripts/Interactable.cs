using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public BoxCollider coll;

    public GameObject crosshair1, crosshair2;
    public GameObject itemNameObject;
    public Text itemName;
    public bool interactable;

    public FlashlightToggle flashlightToggle;
    public SanityManager sanityManager;
    public AudioManager audioManager;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            string objectName = gameObject.name;
            itemNameObject.SetActive(true);
            itemName.text = objectName;
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            itemNameObject.SetActive(false);
            crosshair1.SetActive(true);
            crosshair2.SetActive(false);
            interactable = false;
        }
    }
    private void Update()
    {
        string objectName = gameObject.name;
        if (Input.GetKeyDown(KeyCode.E) && interactable && objectName == "Eat Sanity Pills")
        {
            sanityManager.AffectSanity(50000);
            audioManager.EatPills();
            audioManager.Swallow();
            itemNameObject.SetActive(false);
            crosshair1.SetActive(true);
            crosshair2.SetActive(false);
            interactable = false;
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E) && interactable && objectName == "Old Cup")
        {
            flashlightToggle.AffectBattery(5000);
            flashlightToggle.UpdateBattery();
            audioManager.EatPills();
            audioManager.Swallow();
            itemNameObject.SetActive(false);
            crosshair1.SetActive(true);
            crosshair2.SetActive(false);
            interactable = false;
            Destroy(gameObject);
        }

    }
}
