using UnityEngine;
using System.Collections;

public class BulletFireScript : Photon.MonoBehaviour
{

    public Transform bulletprefab;
    Player _bull;
    Vector3 gun;
    //public bool shotgun= false;
    // Use this for initialization
    public BulletScript spread;
    public GameObject Gun_pos;
    public GameObject Assault_pos;

    public GameObject Shotgun_pos;
    public GameObject Shotgun_pos_1;
    public GameObject Shotgun_pos_2;
    public GameObject Shotgun_pos_3;
    public GameObject Shotgun_pos_4;
    public GameObject Shotgun_pos_5;
    public float BulletForce = 500.0f;
    public bool rifle = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&&(GameManager.Instance.ammocount>0))
        {
            //gun = new Vector3(Gun_pos.transform.position.x+0.5f, Gun_pos.transform.position.y + 0.4f,Gun_pos.transform.position.z+0.5f);

            if (spread.shotgun_spread == true)
            {
                spread.Assault_rifle_spread = false;
                spread.shotgun_spread = true;


                gun = new Vector3(Shotgun_pos.transform.position.x + 0.5f, Shotgun_pos.transform.position.y + 0.4f, Shotgun_pos.transform.position.z + 0.5f);
                Fire(Shotgun_pos.transform.position, transform.rotation);
                //Instantiate(bulletprefab, Shotgun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_1.transform.position.x + 0.45f, Shotgun_pos_1.transform.position.y + 0.4f, Shotgun_pos_1.transform.position.z + 0.5f);
                Fire(Shotgun_pos_1.transform.position, transform.rotation);
                //Instantiate(bulletprefab, Shotgun_pos_1.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_2.transform.position.x + 0.55f, Shotgun_pos_2.transform.position.y + 0.4f, Shotgun_pos_2.transform.position.z + 0.5f);
                Fire(Shotgun_pos_2.transform.position, transform.rotation);
                //Instantiate(bulletprefab, Shotgun_pos_2.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_3.transform.position.x + 0.5f, Shotgun_pos_3.transform.position.y + 0.45f, Shotgun_pos_3.transform.position.z + 0.5f);
                Fire(Shotgun_pos_3.transform.position, transform.rotation);
                //Instantiate(bulletprefab, Shotgun_pos_3.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_4.transform.position.x + 0.5f, Shotgun_pos_4.transform.position.y + 0.35f, Shotgun_pos_4.transform.position.z + 0.5f);
                Fire(Shotgun_pos_4.transform.position, transform.rotation);
                //Instantiate(bulletprefab, Shotgun_pos_4.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_5.transform.position.x + 0.55f, Shotgun_pos_5.transform.position.y + 0.45f, Shotgun_pos_5.transform.position.z + 0.5f);
                Fire(Shotgun_pos_5.transform.position, transform.rotation);
                //Instantiate(bulletprefab, Shotgun_pos_5.transform.position, transform.rotation);
                GameManager.Instance.fire();
                


            }
            if (spread.sniper_spread == true||spread.crossbow_spread==true)
            {
                Fire(Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
            }
            if (spread.Assault_rifle_spread == true)
            {

            }
            else
            {
                Fire(Gun_pos.transform.position, transform.rotation);
                //Gun_pos = _bull.SynchedMovement();
                //_bull.SynchedMovement();
                //Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
            }
        }
        if (Input.GetMouseButton(0) && (GameManager.Instance.ammocount > 0))
        {
            if (spread.Assault_rifle_spread == true)
            {
                if (rifle==false)
                {
                    spread.shotgun_spread = false;
                    gun = new Vector3(Assault_pos.transform.position.x, Assault_pos.transform.position.y, Assault_pos.transform.position.z);
                    Fire(Assault_pos.transform.position, transform.rotation);
                    //Instantiate(bulletprefab, gun, transform.rotation);
                    GameManager.Instance.fire();
                    StartCoroutine(Rapid());
                }

            }

        }
    }

    [PunRPC]
    private void Fire(Vector3 pos, Quaternion dir)
    {
        Instantiate(bulletprefab, pos, dir);

        if (this.photonView.isMine)
        {
            this.photonView.RPC("Fire", PhotonTargets.OthersBuffered, pos, dir);
        }
    }

    IEnumerator Rapid()
    {
        rifle = true;
        yield return new WaitForSeconds(0.05f);
        rifle = false;
    }
}
