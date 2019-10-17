﻿using System.Collections;
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

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo Info)
    {
        if (stream.isWriting)
        {
            //stream.SendNext(GetComponent<Rigidbody>().position);
            //stream.SendNext(GetComponent<Rigidbody>().velocity);
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            //Vector3 syncPosition = (Vector3)stream.ReceiveNext();
            //Vector3 syncVelocity = (Vector3)stream.ReceiveNext();
            Vector3 syncTransformPos = (Vector3)stream.ReceiveNext();
            Quaternion rot = (Quaternion)stream.ReceiveNext();
            //syncTime = 0f;
            //syncDelay = Time.time - lastSynchronizationTime;
            //lastSynchronizationTime = Time.time;
            //syncEndPosition = syncTransformPos * syncDelay;
            //syncStartPosition = GetComponent<Transform>().position;
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
            InputColorChange();
        }
        else
        {
            //SynchedMovement();
        }
    }

    void InputMovement()
    {
        //if (Input.GetKey(KeyCode.W))
        //    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position
        //        + Vector3.forward * speed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.S))
        //    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position
        //        - Vector3.forward * speed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.D))
        //    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position
        //        + Vector3.right * speed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.A))
        //    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position
        //        - Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
            GetComponent<Transform>().Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            GetComponent<Transform>().Translate(Vector3.back * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            GetComponent<Transform>().Translate(Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            GetComponent<Transform>().Translate(Vector3.left * speed * Time.deltaTime);

    }

    private void SynchedMovement()
    {
        syncTime += Time.deltaTime;
        GetComponent<Transform>().position = Vector3.Lerp(syncStartPosition,
            syncEndPosition, syncTime / syncDelay);
    }


    private void InputColorChange()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ChangeColorTo(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f),
                Random.Range(0f, 1f)));
    }

    [PunRPC] void ChangeColorTo (Vector3 color)
    {
        GetComponent<Renderer>().material.color = new Color(color.x, color.y, color.z, 1f);

        if (photonView.isMine)
            photonView.RPC("ChangeColorTo", PhotonTargets.OthersBuffered, color);
    }
}
