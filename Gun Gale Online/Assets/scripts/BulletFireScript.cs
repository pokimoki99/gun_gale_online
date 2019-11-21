using UnityEngine;
using System.Collections;

public class BulletFireScript : MonoBehaviour
{

    public Transform bulletprefab;

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
                Instantiate(bulletprefab, Shotgun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Shotgun_pos_1.transform.position.x + 0.45f, Shotgun_pos_1.transform.position.y + 0.4f, Shotgun_pos_1.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos_1.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Shotgun_pos_2.transform.position.x + 0.55f, Shotgun_pos_2.transform.position.y + 0.4f, Shotgun_pos_2.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos_2.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Shotgun_pos_3.transform.position.x + 0.5f, Shotgun_pos_3.transform.position.y + 0.45f, Shotgun_pos_3.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos_3.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Shotgun_pos_4.transform.position.x + 0.5f, Shotgun_pos_4.transform.position.y + 0.35f, Shotgun_pos_4.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos_4.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Shotgun_pos_5.transform.position.x + 0.55f, Shotgun_pos_5.transform.position.y + 0.45f, Shotgun_pos_5.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos_5.transform.position, transform.rotation);
                GameManager.Instance.fire();
                


            }
            if (spread.Assault_rifle_spread == true)
            {

            }
            else
            {
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
            }
        }
        if (Input.GetMouseButton(0) && (GameManager.Instance.ammocount > 0))
        {
            if (spread.Assault_rifle_spread == true)
            {
                spread.shotgun_spread = false;
                gun = new Vector3(Assault_pos.transform.position.x, Assault_pos.transform.position.y, Assault_pos.transform.position.z);
                Instantiate(bulletprefab, gun, transform.rotation);
                GameManager.Instance.fire();
            }

        }
    }
}
