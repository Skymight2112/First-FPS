using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : MonoBehaviour
{

    private const string PLAYER_TAG = "Player";

    public Camera FpsCam;

    public PlayerWeapon weapon;


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
        if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hit, weapon.range))
        {
            if (hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(hit.collider.name);

            }
            Debug.Log(hit.collider.name);

        }
    }

  
    [Command]
    void CmdPlayerShot(string _PlayerID)
    {
        Debug.Log(_PlayerID + " has been shot.");
    }
}
