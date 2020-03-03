﻿using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


[System.Serializable]
public class PlayerWeapon : MonoBehaviour
{
    //private const string PLAYER_TAG = "Player";

    public new string name = "Glock";

    public float damage = 10f;
    public float range = 100f;

    /*public Camera FpsCam;


    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hit, range))
        {
            if (hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerShot (string _PlayerID)
    {
        Debug.Log(_PlayerID + " has been shot.");
    }
*/
}
