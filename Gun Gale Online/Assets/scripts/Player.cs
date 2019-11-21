using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour
{
    public float speed = 10f;
    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;
    private Vector3 syncStartRotation = Vector3.zero;
    private Vector3 syncEndRotation = Vector3.zero;
    public GameObject camera;
    public GameObject bullet;

    //public bool syncLocalRotation = true;
    public int score = 0;
    public BulletScript spread;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject rifle;

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo Info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(GetComponent<Rigidbody>().position);
            //stream.SendNext(GetComponent<Rigidbody>().rotation);
            stream.SendNext(GetComponent<Rigidbody>().velocity);
        }
        else
        {
            Vector3 syncPosition = (Vector3)stream.ReceiveNext();
            //Vector3 syncRotation = (Vector3)stream.ReceiveNext();
            Vector3 syncVelocity = (Vector3)stream.ReceiveNext();
            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;
            syncEndPosition = syncPosition + syncVelocity * syncDelay;
            syncStartPosition = GetComponent<Rigidbody>().position;
            //syncEndRotation = syncRotation + syncVelocity * syncDelay;
            //syncStartRotation = GetComponent<Rigidbody>().rotation;
        }
    }

    void Awake()
    {
        lastSynchronizationTime = Time.time;
        pistol.SetActive(false);
        shotgun.SetActive(false);
        rifle.SetActive(false);
        spread.pistol_spread = false;
        spread.shotgun_spread = false;
        spread.Assault_rifle_spread = false;

    }
    void Update()
    {
        //if (syncLocalRotation) myTransform.localRotation = Quaternion.Slerp(lhs.rot, rhs.rot, t);

        if (Input.GetKey(KeyCode.K))
        {
            score = 1;
        }
        if (Input.GetKey(KeyCode.L))
        {
            score = 0;
        }
        if (Input.GetKey(KeyCode.J))
        {
            score = 2;
        }
        if (score == 0)
        {
            spread.pistol_spread = true;
            spread.shotgun_spread = false;
            spread.Assault_rifle_spread = false;
            pistol.SetActive(true);
            shotgun.SetActive(false);
            rifle.SetActive(false);

        }
        if (score == 1)
        {
            spread.pistol_spread = false;
            spread.shotgun_spread = true;
            spread.Assault_rifle_spread = false;
            pistol.SetActive(false);
            shotgun.SetActive(true);
            rifle.SetActive(false);

        }
        if (score == 2)
        {
            spread.Assault_rifle_spread = true;
            spread.shotgun_spread = false;
            spread.pistol_spread = false;
            shotgun.SetActive(false);
            pistol.SetActive(false);
            rifle.SetActive(true);

        }

        if (photonView.isMine)
        {
            InputMovement();
            bullet.SetActive(true);
        }
        else
        {
            SynchedMovement();
            camera.SetActive(false);
            //bullet.SetActive(false);
            gameObject.GetComponent<BulletFireScript>().enabled = false;
            //gameObject.transform.rotation


        }
    }

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position
                + Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position
                - Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position
                + Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position
                - Vector3.right * speed * Time.deltaTime);


    }

    private void SynchedMovement()
    {
        syncTime += Time.deltaTime;
        GetComponent<Rigidbody>().position = Vector3.Lerp(syncStartPosition,
            syncEndPosition, syncTime / syncDelay);
    }


}
