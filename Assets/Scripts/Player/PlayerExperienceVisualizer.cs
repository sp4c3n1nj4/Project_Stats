using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperienceVisualizer : MonoBehaviour
{
    [SerializeField]
    PlayerExperience playerExperience;
    [SerializeField]
    Slider slider;
    [SerializeField]
    TextMeshProUGUI TextMeshPro;

    void Start()
    {
        playerExperience.PlayerExpGain.AddListener(OnExpGain);
    }

    private void OnExpGain(float currentExp, float maxExp)
    {
        float expPercentage = currentExp / maxExp;
        Mathf.Clamp(expPercentage, 0, 1);
        
        slider.value = expPercentage;

        TextMeshPro.text = currentExp.ToString() + " / " + maxExp.ToString();
    }
}
