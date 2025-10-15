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
    public UnityEngine.UI.Toggle MotionBlurToggle;

    public float Brightness = 1;

    private bool ResetAll = false;

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

        #region Motion Blur

        if (!Profile.TryGet<MotionBlur>(out var motionBlur))
        {
            motionBlur = Profile.Add<MotionBlur>(false);
        }

        motionBlur.active = MotionBlurToggle.isOn;

        #endregion

        #region Reset All

        if(ResetAll)
        {
            BrightnessSlider.value = 1;
            ChromaticToggle.SetIsOnWithoutNotify(true);
            GrainToggle.SetIsOnWithoutNotify(true);
            MotionBlurToggle.SetIsOnWithoutNotify(true);

            ResetAll = false;
        }
        
        #endregion

    }

    public void ResetBrightness()
    {
        BrightnessSlider.value = 1;
    }

    public void ResetSettings()
    {
        ResetAll = true;
    }
}
