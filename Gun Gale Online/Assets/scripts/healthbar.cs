using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    Image barImage;
    Image barImage1;
    public Health health;
    //public bool Damage_Taken = false;


    public void Awake()
    {
        barImage = GameObject.FindWithTag("playerhp").GetComponent<Image>();
        barImage1 = GameObject.FindWithTag("enemyhp").GetComponent<Image>();

        health = new Health();


    }
    public void Update()
    {
        health.Update();

        barImage.fillAmount = health.GetHealthNormalized();
        barImage1.fillAmount = health.GetHealthNormalized1();
    }

    public class Health
    {
        public const int HEALTH_MAX = 100;
        public const int HEALTH_MAX1 = 100;

        public float healthAmount;
        public float healthAmount1;

        public bool dead = false;

        public float healthRegenAmount;
        public float healthRegenAmount1;

        public Health()
        {
            healthAmount = 90;
            healthAmount1 = 90;



            healthRegenAmount = 5f;
            healthRegenAmount1 = 5f;
        }
        public void Update()
        {
            if (healthAmount < HEALTH_MAX)
            {
                healthAmount += healthRegenAmount * Time.deltaTime;
            }
            if (healthAmount <= 10)
            {
                //healthRegenAmount = 0;
                dead = true;
            }
            if (healthAmount1 < HEALTH_MAX1)
            {
                healthAmount1 += healthRegenAmount1 * Time.deltaTime;
            }
            if (healthAmount1 <= 10)
            {
                //healthRegenAmount = 0;
                dead = true;
            }
            if (dead)
            {
                healthAmount = 100;
                healthAmount1 = 100;
                dead = false;
            }
        }

        public void Damage(int DamageAmount)
        {
            if (healthAmount >= DamageAmount)
            {
                healthAmount -= DamageAmount;
            }
            else
            {
            }
        }
        public void Damage1(int DamageAmount)
        {
            if (healthAmount1 >= DamageAmount)
            {
                healthAmount1 -= DamageAmount;
            }
            else
            {
            }
        }
        public float GetHealthNormalized()
        {
            return healthAmount / HEALTH_MAX;
        }
        public float GetHealthNormalized1()
        {
            return healthAmount1 / HEALTH_MAX1;
        }
    }

}