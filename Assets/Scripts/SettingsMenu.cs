using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingsMenu : MonoBehaviour
{
    public UnityEngine.UI.Slider BrightnessSlider;
    public Volume Volume;
    VolumeProfile Profile;

    public float Brightness = 1;

    void Start()
    {
        Profile = Volume.sharedProfile;
    }

    void Update()
    {
        Brightness = BrightnessSlider.value;

        if(!Profile.TryGet<ColorAdjustments>(out var colorAdj))
        {
            colorAdj = Profile.Add<ColorAdjustments>(false);
        }

        colorAdj.postExposure.value = Brightness;

    }
}
