using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{
    public Image healthImage;
    public Image healthDelayImage;

    public void OnHealthChange(float percentage)
    {
        healthImage.fillAmount = percentage;
    }
}
