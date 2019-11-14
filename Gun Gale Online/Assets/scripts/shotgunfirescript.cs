
using UnityEngine;
using System.Collections;

public class shotgunfirescript : MonoBehaviour
{

    public Transform bulletprefab;
    public GameObject sGun_pos;
    Vector3 gun;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && (GameManager.Instance.ammocount > 0))
        {
            gun = new Vector3(sGun_pos.transform.position.x + 0.5f, sGun_pos.transform.position.y + 0.4f, sGun_pos.transform.position.z + 0.5f);
            Instantiate(bulletprefab, sGun_pos.transform.position, transform.rotation);
            GameManager.Instance.fire();
            gun = new Vector3(sGun_pos.transform.position.x + 0.45f, sGun_pos.transform.position.y + 0.4f, sGun_pos.transform.position.z + 0.5f);
            Instantiate(bulletprefab, sGun_pos.transform.position, transform.rotation);
            GameManager.Instance.fire();
            gun = new Vector3(sGun_pos.transform.position.x + 0.55f, sGun_pos.transform.position.y + 0.4f, sGun_pos.transform.position.z + 0.5f);
            Instantiate(bulletprefab, sGun_pos.transform.position, transform.rotation);
            GameManager.Instance.fire();
            gun = new Vector3(sGun_pos.transform.position.x + 0.5f, sGun_pos.transform.position.y + 0.45f, sGun_pos.transform.position.z + 0.5f);
            Instantiate(bulletprefab, sGun_pos.transform.position, transform.rotation);
            GameManager.Instance.fire();
            gun = new Vector3(sGun_pos.transform.position.x + 0.5f, sGun_pos.transform.position.y + 0.35f, sGun_pos.transform.position.z + 0.5f);
            Instantiate(bulletprefab, sGun_pos.transform.position, transform.rotation);
            GameManager.Instance.fire();
            gun = new Vector3(sGun_pos.transform.position.x + 0.55f, sGun_pos.transform.position.y + 0.45f, sGun_pos.transform.position.z + 0.5f);
            Instantiate(bulletprefab, sGun_pos.transform.position, transform.rotation);
            GameManager.Instance.fire();
            gun = new Vector3(sGun_pos.transform.position.x + 0.45f, sGun_pos.transform.position.y + 0.45f, sGun_pos.transform.position.z + 0.5f);
            Instantiate(bulletprefab, sGun_pos.transform.position, transform.rotation);
            GameManager.Instance.fire();
            gun = new Vector3(sGun_pos.transform.position.x + 0.55f, sGun_pos.transform.position.y + 0.35f, sGun_pos.transform.position.z + 0.5f);
            Instantiate(bulletprefab, sGun_pos.transform.position, transform.rotation);
            GameManager.Instance.fire();
            gun = new Vector3(sGun_pos.transform.position.x + 0.45f, sGun_pos.transform.position.y + 0.35f, sGun_pos.transform.position.z + 0.5f);
            Instantiate(bulletprefab, sGun_pos.transform.position, transform.rotation);
            GameManager.Instance.fire();

        }
    }
}
