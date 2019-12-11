using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    Image barImage;
    public Health health;
    //public bool Damage_Taken = false;


    public void Awake()
    {
        barImage = GameObject.FindWithTag("Health").GetComponent<Image>();

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

        public float healthAmount;
        public bool dead = false;

        public float healthRegenAmount;
        public Health()
        {
            healthAmount = 90;
            healthRegenAmount = 5f;
        }
        public void Update()
        {
            if (healthAmount < HEALTH_MAX)
            {
                healthAmount += healthRegenAmount * Time.deltaTime;
            }
            if (healthAmount <= 10)
            {
                healthRegenAmount = 0;
                dead = true;
            }
            if (dead)
            {
                healthAmount = 100;
                dead = false;
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
                //Debug.Log("Damage Taken " + DamageAmount);
            }
            else
            {
                //Debug.Log("Too much Damage");
            }
        }
        public float GetHealthNormalized()
        {
            return healthAmount / HEALTH_MAX;
        }
    }
}