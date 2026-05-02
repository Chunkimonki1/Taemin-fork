using UnityEngine;

public class Gun : MonoBehaviour
{
    public float speed = 100f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Camera cam;
    public GameObject muzzleFlash;
    public GameObject gun;
    public Transform lookPosition;

    public float recoil;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        gun.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100f);
        }
        Vector3 direction = gun.transform.forward;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        Instantiate(muzzleFlash, firePoint.position, Quaternion.LookRotation(direction));

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;

        //gun.transform.parent.GetComponent<Rigidbody>().AddExplosionForce(100, firePoint.position, 0, 0, ForceMode.Impulse);
        gun.transform.parent.GetComponent<Rigidbody>().AddForce(-direction*recoil, ForceMode.Impulse);
        float lookRecoil = recoil*1000;
        lookPosition.position = new Vector3(Random.Range(-lookRecoil, lookRecoil), Random.Range(-lookRecoil, lookRecoil), Random.Range(-lookRecoil, lookRecoil)) ;

        Destroy(bullet, 2f);
    }
}