using UnityEngine;
using System.Collections;

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
    Vector3 rand;


    private float syncTime = 0f;
    private float syncDelay = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        if (shotgun_spread == true)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * (force-250.0f));
            Debug.Log("work?");

        }
        else if (Assault_rifle_spread == true)
        {
            Debug.Log("rifle?");
            GetComponent<Rigidbody>().AddForce(transform.forward * (force+200.0f));
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

    public void SynchedBullet()
    {

        syncTime += Time.deltaTime;
        GetComponent<Rigidbody>().position = Vector3.Lerp(syncStartPosition,
            syncEndPosition, syncTime / syncDelay);
    }
}
