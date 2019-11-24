using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    private Image barImage;
    private Health health;

    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        health = new Health();
    }
    private void Update()
    {
        health.Update();

        barImage.fillAmount = health.GetHealthNormalized();
    }
}
public class Health
{
    public const int HEALTH_MAX = 100;

    private float healthAmount;
    private float healthRegenAmount;

    public Health()
    {
        healthAmount = 0;
        healthRegenAmount = 10f;
    }
    public void Update()
    {
        healthAmount += healthRegenAmount * Time.deltaTime;
    }
    public void Damage(int DamageAmount)
    {
        if (healthAmount >= DamageAmount)
        {
            healthAmount -= DamageAmount;
        }
    }
    public float GetHealthNormalized()
    {
        return healthAmount / HEALTH_MAX;
    }
}
