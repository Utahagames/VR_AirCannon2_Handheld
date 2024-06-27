using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCannon : MonoBehaviour
{
    [SerializeField] Transform cannon_body_transform;
    [SerializeField] GameObject bullet_prefab;
    [SerializeField] float _shotSpeed;
    [SerializeField] float _shotAccel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShotCannon();
        }
    }
    void ShotCannon()
    {
        GameObject bullet = Instantiate(bullet_prefab, cannon_body_transform.position, Quaternion.identity);

        Bullet bulletState = bullet.GetComponent<Bullet>();

        bulletState._speed = _shotSpeed;
        bulletState._accel = _shotAccel;

        //Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        //bulletRb.AddForce(beforeTransform.forward * 400);
        Destroy(bullet, 3.0f);
    }
}
