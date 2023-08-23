using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefabý
    public float bulletSpeed = 10f; // Mermi hýzý

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Fare sol týklamasý algýlama
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Kameranýn ortasýndan ýþýn oluþtur
        RaycastHit hitInfo;

        // Iþýnýn hedefe ulaþýp ulaþmadýðýný kontrol et
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            string hitObjectTag = hitObject.tag;
            Debug.Log("Hit object tag: " + hitObjectTag);
        }

        // Mermi oluþturma ve hedefe gönderme
        GameObject bullet = Instantiate(bulletPrefab, ray.origin, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = ray.direction * bulletSpeed;
        }
    }
}
