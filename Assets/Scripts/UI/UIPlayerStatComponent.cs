using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIPlayerStatComponent : MonoBehaviour
{
    public Enum statKey;

    [SerializeField]
    TextMeshProUGUI statNameText, statValueText;

    public void UpdateText()
    {
        statNameText.text = statKey.ToString();
        statValueText.text = PlayerStatsCounter.PlayerStatistics[statKey].ToString();
    }

    public void StatUpButton()
    {
        PlayerStatsCounter.IncreaseStat(statKey, 1);
        UpdateText();
    }
}
