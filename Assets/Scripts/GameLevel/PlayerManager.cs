
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;

    [SerializeField]
    private Transform bulletPosition;

    float angle;

    float rotationSpeed = 100f;

    [SerializeField]
    private GameObject[] bulletPrefab;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip shotSound;


    float timeBetweenShots = 200f;

    float nextShot;

    public bool shouldRotate;

    private void Start()
    {
        shouldRotate = false;
    }

    void Update()
    {
        if (shouldRotate)
        {
            ChangeRotation();
        }
    }

    void ChangeRotation()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (angle < 45 && angle > -45)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextShot)
            {
                nextShot = Time.time + timeBetweenShots / 1000;
                FireBullet();
            }
        }
    }

    void FireBullet()
    {
        if (PlayerPrefs.GetInt("soundStatus") == 1)
        {
            audioSource.PlayOneShot(shotSound);
        }

        Instantiate(bulletPrefab[Random.Range(0, bulletPrefab.Length)], bulletPosition.position, bulletPosition.rotation);
    }
}