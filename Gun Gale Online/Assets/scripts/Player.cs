using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour
{
    public float speed = 10f;
    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;
    public GameObject camera;

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo Info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(GetComponent<Rigidbody>().position);
            stream.SendNext(GetComponent<Rigidbody>().velocity);
        }
        else
        {
            Vector3 syncPosition = (Vector3)stream.ReceiveNext();
            Vector3 syncVelocity = (Vector3)stream.ReceiveNext();
            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;
            syncEndPosition = syncPosition + syncVelocity * syncDelay;
            syncStartPosition = GetComponent<Rigidbody>().position;
        }
    }

    void Awake()
    {
        lastSynchronizationTime = Time.time;

    }
    void Update()
    {
       
        if (photonView.isMine)
        {
            InputMovement();
        }
        else
        {
            SynchedMovement();
            camera.SetActive(false);

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
