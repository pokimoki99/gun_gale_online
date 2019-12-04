﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    private Image barImage;
    public Health health;
    //public bool Damage_Taken = false;
    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        health = new Health();


    }
    public void Update()
    {
        health.Update();

        barImage.fillAmount = health.GetHealthNormalized();
    }

    public class Health
    {
        public const int HEALTH_MAX = 100;

        private float healthAmount;
        private float healthRegenAmount;
        public Health()
        {
            healthAmount = 90;
            healthRegenAmount = 10f;
        }
        public void Update()
        {
            if(healthAmount < HEALTH_MAX)
            {
            healthAmount += healthRegenAmount * Time.deltaTime;
            }
            
        }
        
       
        
        public void Damage(int DamageAmount)
        {
            //if (BulletScript.Damage_Taken = true)
            //{

            //}
            if (healthAmount >= DamageAmount)
            {
                healthAmount -= DamageAmount;
                Debug.Log("Damage Taken " + DamageAmount);
            }
            else
            {
                Debug.Log("Too much Damage");
            }
        }
        public float GetHealthNormalized()
        {
            return healthAmount / HEALTH_MAX;
        }
    }
}