using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    GameManager gm;
    GameObject explosion;
    public GameObject bullet;
    public GameObject explosionprefab;
    public float force = 500.0f;
    public bool shotgun_spread=false;
    public bool Assault_rifle_spread = false;
    Vector3 rand;

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        if (shotgun_spread == true)
        {
            //GetComponent<Rigidbody>().AddForce((transform.forward+rand) * force);
            GetComponent<Rigidbody>().AddForce(rand * force);
            //bullet.transform.Rotate(0.0f,bullet.transform.rotation.y + 10.0f,0.0f);
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
        //if (col.gameObject.tag == "EnemyNPC")
        //{
        //    gm.incscore(1);
        //    Destroy(col.gameObject);// the cube
        //    explosion = Instantiate(explosionprefab, this.transform.position, this.transform.rotation) as GameObject;
        //    Destroy(explosion, 5.0f); // the explosion
        //}
        if (col.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Player")
        {
            gm.incscore(10);
            Destroy(gameObject);

        }
        //else if (col.gameObject.tag == "Sphere")
        //{
        //    gm.incscore(20);
        //    Destroy(col.gameObject);// the cube
        //    explosion = Instantiate(explosionprefab, this.transform.position, this.transform.rotation) as GameObject;
        //    Destroy(explosion, 5.0f); // the explosion
        //}


        //Destroy(gameObject); // the bullet

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
