﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{

    GameManager gm;
    GameObject explosion;
    public GameObject bullet;
    public GameObject explosionprefab;
    public float force = 500.0f;
    public bool pistol_spread=false;
    public bool shotgun_spread=false;
    public bool Assault_rifle_spread = false;

    public healthbar _hp;

    
    Vector3 rand;

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        if (shotgun_spread == true)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * force);
            Debug.Log("work?");

        }
        else if (Assault_rifle_spread == true)
        {
            Debug.Log("rifle?");
            GetComponent<Rigidbody>().AddForce(transform.forward * force);
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * force);
        }

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Player")
        {
            //GetComponent<healthbar.Health>().Damage(DamageAmount: 10);
            //healthbar.Health.Damage(5);
            _hp.health.Damage(5);

            //healthbar.
            gm.incscore(1);
            Destroy(gameObject);
        }
    }

    void main()
    {
        if (gameObject.transform.position.y <= 0)
        {
            Destroy(gameObject);
        }

    }
    public void random()
    {
        rand = new Vector3(0, Random.Range(0.0f, 1.0f), 0);
    }
}
