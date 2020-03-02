using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


[System.Serializable]
public class PlayerWeapon : MonoBehaviour
{
    public new string name = "Glock";

    public float damage = 10f;
    public float range = 100f;

    public Camera FpsCam;


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
            Debug.Log(hit.transform.name);
        }
    }

}
