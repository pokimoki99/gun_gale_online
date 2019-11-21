using UnityEngine;
using System.Collections;

public class BulletFireScript : MonoBehaviour
{

    public Transform bulletprefab;
    public GameObject Gun_pos;
    Vector3 gun;
    public bool shotgun= false;
    // Use this for initialization
    BulletScript spread;
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

            if (shotgun == true)
            {
                Debug.Log(shotgun);
                //for (int i = 0; i <= 8; i++)
                //{
                //    Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                //    GameManager.Instance.fire();
                //    Debug.Log("fire");
                //}
                gun = new Vector3(Gun_pos.transform.position.x + 0.5f, Gun_pos.transform.position.y + 0.4f, Gun_pos.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Gun_pos.transform.position.x + 0.45f, Gun_pos.transform.position.y + 0.4f, Gun_pos.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Gun_pos.transform.position.x + 0.55f, Gun_pos.transform.position.y + 0.4f, Gun_pos.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Gun_pos.transform.position.x + 0.5f, Gun_pos.transform.position.y + 0.45f, Gun_pos.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Gun_pos.transform.position.x + 0.5f, Gun_pos.transform.position.y + 0.35f, Gun_pos.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Gun_pos.transform.position.x + 0.55f, Gun_pos.transform.position.y + 0.45f, Gun_pos.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Gun_pos.transform.position.x + 0.45f, Gun_pos.transform.position.y + 0.45f, Gun_pos.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Gun_pos.transform.position.x + 0.55f, Gun_pos.transform.position.y + 0.35f, Gun_pos.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
                gun = new Vector3(Gun_pos.transform.position.x + 0.45f, Gun_pos.transform.position.y + 0.35f, Gun_pos.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
                spread.shotgun_spread = true;
                int z = 0;


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
                //shotgun = false;
                gun = new Vector3(Gun_pos.transform.position.x, Gun_pos.transform.position.y, Gun_pos.transform.position.z);
                Instantiate(bulletprefab, gun, transform.rotation);
                GameManager.Instance.fire();
            }

        }
    }
}
