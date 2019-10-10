using UnityEngine;
using System.Collections;

public class BulletFireScript : MonoBehaviour
{

    public Transform bulletprefab;
    public GameObject Gun_pos;
    Vector3 gun;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&&(GameManager.Instance.ammocount>0))
        {
            gun = new Vector3(Gun_pos.transform.position.x, Gun_pos.transform.position.y + 0.4f,Gun_pos.transform.position.z);
            Instantiate(bulletprefab, gun, transform.rotation);
            GameManager.Instance.fire();
        }
    }
}
