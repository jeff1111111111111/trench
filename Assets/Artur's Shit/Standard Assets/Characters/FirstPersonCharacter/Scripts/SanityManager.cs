using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SanityManager : MonoBehaviour
{
    private Slider sanitySlider;
    public int fullSanity;
    public int difficulty;
    public PostProcessProfile profile;
    Vignette vignette;
    float percent;
    
    // Start is called before the first frame update
    void Start()
    {
        profile.TryGetSettings(out vignette);
        sanitySlider = GetComponent<Slider>();
        sanitySlider.maxValue = fullSanity;
        sanitySlider.value = fullSanity;
        vignette.intensity.value = 0;
        StartCoroutine(LoseSanity());
    }

    IEnumerator LoseSanity()
    {
        while(sanitySlider.value > 0)
        {
           
            sanitySlider.value -= 1f * difficulty;
            float newValue = (sanitySlider.value - sanitySlider.maxValue) * -1;
            percent = newValue / sanitySlider.maxValue;
            vignette.intensity.value = percent;
            yield return null;
        }
        Debug.Log("Youre nuts");
    }
    public void AffectSanity(float value)
    {
        sanitySlider.value += value;
    }
}
