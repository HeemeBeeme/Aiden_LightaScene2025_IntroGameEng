using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingsMenu : MonoBehaviour
{
    public UnityEngine.UI.Slider BrightnessSlider;
    public Volume Volume;
    VolumeProfile Profile;

    public UnityEngine.UI.Toggle ChromaticToggle;
    public UnityEngine.UI.Toggle GrainToggle;

    public float Brightness = 1;

    void Start()
    {
        Profile = Volume.sharedProfile;
    }

    void Update()
    {
        #region Brightness

        Brightness = BrightnessSlider.value;

        if(!Profile.TryGet<ColorAdjustments>(out var colorAdj))
        {
            colorAdj = Profile.Add<ColorAdjustments>(false);
        }

        colorAdj.postExposure.value = Brightness;
        #endregion

        #region Chromatic Aberration

        if (!Profile.TryGet<ChromaticAberration>(out var chromaticAbr))
        {
            chromaticAbr = Profile.Add<ChromaticAberration>(false);
        }

        chromaticAbr.active = ChromaticToggle.isOn;

        #endregion

        #region Film Grain

        if (!Profile.TryGet<FilmGrain>(out var filmGrain))
        {
            filmGrain = Profile.Add<FilmGrain>(false);
        }

        filmGrain.active = GrainToggle.isOn;

        #endregion

    }

    public void ResetBrightness()
    {
        BrightnessSlider.value = 1;
    }
}
