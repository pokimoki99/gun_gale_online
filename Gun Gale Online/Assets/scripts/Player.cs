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

    CharacterController characterController;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 moveRotation = Vector3.zero;


    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo Info)
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

    public void Awake()
    {
        gameObject.GetComponent<Rigidbody>();
        lastSynchronizationTime = Time.time;
        pistol.SetActive(false);
        shotgun.SetActive(false);
        rifle.SetActive(false);
        spread.pistol_spread = false;
        spread.shotgun_spread = false;
        spread.Assault_rifle_spread = false;

        characterController = GetComponent<CharacterController>();

    }
    public void Update()
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
            //GameManager.Instance.Ammo()
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

        if (this.photonView.isMine)
        {
            InputMovement();
            bullet.SetActive(true);
            gameObject.GetComponent<BulletFireScript>().enabled = true;
        }
        else
        {
            SynchedMovement();
            spread.SynchedBullet();
            camera.SetActive(false);
            //bullet.SetActive(false);
            gameObject.GetComponent<BulletFireScript>().enabled = false;


        }
    }

    public void InputMovement()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }

        if (Input.GetKey("w"))
        {
            transform.position += camera.transform.forward * (Time.deltaTime * speed);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 80, 2 * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            transform.position += -camera.transform.forward * (Time.deltaTime * speed);
        }
        if (Input.GetKey("a"))
        {
            transform.position += -camera.transform.right * (Time.deltaTime * speed);
        }
        if (Input.GetKey("d"))
        {
            transform.position += camera.transform.right * (Time.deltaTime * speed);
        }
    }

    public void SynchedMovement()
    {
        syncTime += Time.deltaTime;
        GetComponent<Rigidbody>().position = Vector3.Lerp(syncStartPosition,
            syncEndPosition, syncTime / syncDelay);
    }



}
