using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperienceVisualizer : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    TextMeshProUGUI TextMeshPro;

    void Start()
    {
        PlayerExperience.PlayerExpGain.AddListener(OnExpGain);
    }

    private void OnExpGain(float currentExp)
    {
        float expPercentage = currentExp / PlayerExperience.CurrentLevelExperienceRequirement();
        Mathf.Clamp(expPercentage, 0, 1);
        
        slider.value = expPercentage;

        TextMeshPro.text = currentExp.ToString() + " / " + PlayerExperience.CurrentLevelExperienceRequirement().ToString();
    }
}
