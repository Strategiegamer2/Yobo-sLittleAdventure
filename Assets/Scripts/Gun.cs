using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public AudioSource ShotgunSound;

    public GameObject RightSideGun;
    public GameObject LeftSideGun;
    public GameObject UpSideGun;
    public GameObject DownSideGun;

    public bool Attack;
    private GameObject Bullet;

    [SerializeField] private Transform ProjectileSpawnPosition; // GameObject that determines where the proj spawns
    [SerializeField] private Transform ProjectileSpawnPosition_2; // GameObject that determines where the proj spawns
    [SerializeField] private Transform ProjectileSpawnPosition_3; // GameObject that determines where the proj spawns
    [SerializeField] private Transform ProjectileSpawnPosition_4; // GameObject that determines where the proj spawns
    [SerializeField] private Transform AimOrigin; // Parented to Player. Has AimLook Script
    [SerializeField] private GameObject BulletPrefab;

    [SerializeField] private int NumberOfProjectiles = 3;
    [SerializeField] private float BulletForce = 20f;

    [Range(0, 360)]
    [SerializeField] private float SpreadAngle = 20;


    // Start is called before the first frame update
    void Start()
    {
        RightSideGun.SetActive(false);
        LeftSideGun.SetActive(false);
        Attack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            UpSideGun.SetActive(true);
            DownSideGun.SetActive(false);
            RightSideGun.SetActive(false);
            LeftSideGun.SetActive(false);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift) == false)
        {
            UpSideGun.SetActive(false);
            DownSideGun.SetActive(false);
            RightSideGun.SetActive(false);
            LeftSideGun.SetActive(true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            DownSideGun.SetActive(true);
            UpSideGun.SetActive(false);
            RightSideGun.SetActive(false);
            LeftSideGun.SetActive(false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            DownSideGun.SetActive(false);
            UpSideGun.SetActive(false);
            LeftSideGun.SetActive(false);
            RightSideGun.SetActive(true);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) == false)
        {
            RightSideGun.SetActive(true);
            LeftSideGun.SetActive(false);
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.D) == false)
        {
            LeftSideGun.SetActive(true);
            RightSideGun.SetActive(false);
        }


        if (LeftSideGun.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.R) && Attack == true)
            {
                Shoot();
            }
        }
        if (RightSideGun.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.R) && Attack == true)
            {
                Attack = false;
                Shoot_2();
            }
        }
        if (UpSideGun.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.R) && Attack == true)
            {
                Shoot_3();
            }
        }
        if (DownSideGun.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.R) && Attack == true)
            {
                Shoot_4();
            }
        }
    }
    private void Shoot()
    {
        float angleStep = SpreadAngle / NumberOfProjectiles;
        float aimingAngle = AimOrigin.rotation.eulerAngles.z;
        float centeringOffset = (SpreadAngle / 2) - (angleStep / 2);                                                                                                                     

        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            float currentBulletAngle = angleStep * i;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
            GameObject bullet = Instantiate(BulletPrefab, ProjectileSpawnPosition.position, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-bullet.transform.right * BulletForce, ForceMode2D.Impulse);
            StartCoroutine(WaitUntilReloaded());
            StartCoroutine(DestroyBullets());
        }
    }
    private void Shoot_2()
    {
        float angleStep = SpreadAngle / NumberOfProjectiles;
        float aimingAngle = AimOrigin.rotation.eulerAngles.z;
        float centeringOffset = (SpreadAngle / 2) - (angleStep / 2); //offsets every projectile so the spread is                                                                                                                       

        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            float currentBulletAngle = angleStep * i;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
            GameObject bullet = Instantiate(BulletPrefab, ProjectileSpawnPosition_2.position, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.right * BulletForce, ForceMode2D.Impulse);
            StartCoroutine(WaitUntilReloaded());
            StartCoroutine(DestroyBullets());
        }
    }
    private void Shoot_3()
    {
        float angleStep = SpreadAngle / NumberOfProjectiles;
        float aimingAngle = AimOrigin.rotation.eulerAngles.z;
        float centeringOffset = (SpreadAngle / 2) - (angleStep / 2);                                                                                                                      

        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            float currentBulletAngle = angleStep * i;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
            GameObject bullet = Instantiate(BulletPrefab, ProjectileSpawnPosition_3.position, rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.up * BulletForce, ForceMode2D.Impulse);
            StartCoroutine(WaitUntilReloaded());
            StartCoroutine(DestroyBullets());
        }
    }
    private void Shoot_4()
    {
        float angleStep = SpreadAngle / NumberOfProjectiles;
        float aimingAngle = AimOrigin.rotation.eulerAngles.z;
        float centeringOffset = (SpreadAngle / 2) - (angleStep / 2);                                                                                                                  

        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            float currentBulletAngle = angleStep * i; // everything before here, that al comes down to the line below

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));// makes it so that the bullets are in a spread formation and you can still change everything.
            GameObject bullet = Instantiate(BulletPrefab, ProjectileSpawnPosition_4.position, rotation); // instantiate bullet

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(-bullet.transform.up * BulletForce, ForceMode2D.Impulse);
            StartCoroutine(WaitUntilReloaded());
            StartCoroutine(DestroyBullets());
        }
    }
    IEnumerator WaitUntilReloaded()
    {
        ShotgunSound.Play();
        yield return new WaitForSeconds(0.3f); // wait a few seconds before you can fire again
        Attack = true;
    }

    IEnumerator DestroyBullets()
    {
        Bullet = GameObject.Find("Bullet(Clone)"); //destroys bullet after 5 seconds
        yield return new WaitForSeconds(5);
        Destroy(Bullet);
    }
}
