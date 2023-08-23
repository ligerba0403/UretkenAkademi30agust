using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab�
    public float bulletSpeed = 10f; // Mermi h�z�

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Fare sol t�klamas� alg�lama
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Kameran�n ortas�ndan ���n olu�tur
        RaycastHit hitInfo;

        // I��n�n hedefe ula��p ula�mad���n� kontrol et
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            string hitObjectTag = hitObject.tag;
            Debug.Log("Hit object tag: " + hitObjectTag);
        }

        // Mermi olu�turma ve hedefe g�nderme
        GameObject bullet = Instantiate(bulletPrefab, ray.origin, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = ray.direction * bulletSpeed;
        }
    }
}
