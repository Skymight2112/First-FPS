using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : MonoBehaviour
{
    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    private void Start()
    {
        if (cam != null)
        {
            Debug.Log("PlayerShoot: No camera referenced");
            this.enabled = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit _Hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _Hit, weapon.range, mask))
        {
            Debug.Log("we hit " + _Hit.collider.name);


        }
    }

}