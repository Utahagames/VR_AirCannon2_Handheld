using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCannon : MonoBehaviour
{
    [SerializeField] Transform cannon_body_transform;
    [SerializeField] Transform fixedcannon_body_transform;
    [SerializeField] GameObject bullet_prefab;
    [SerializeField] Transform _controller;
    [SerializeField] float _shotBorder;
    [SerializeField] int _coolframe;
    [SerializeField] int _lateframe;
    [SerializeField] float _shotSpeed;

    Vector3 pos_cannon;
    Vector3 roat_cannon;

    private Vector3 _lastControllerPos;

    private int count_cooltime = 0;

    private Transform _last_cannon_transform;
    private List<Transform> keepTransform = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        _lastControllerPos = _controller.position;
        _last_cannon_transform = cannon_body_transform;
        keepTransform[0] = cannon_body_transform;
    }

    // Update is called once per frame
    void Update()
    {
        //pos_cannon = new Vector3(right_transform.position.x, right_transform.position.y, right_transform.position.z);
        //roat_cannon = new Vector3(right_transform.rotation.x + 30.0f, right_transform.position.y, right_transform.position.z + 40.0f);
        //transform.position = pos_cannon;
        //transform.rotation = right_transform.rotation;
        //transform.Rotate( -28.0f, -30.0f, 20.0f);


        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            ShotCannon();
        }


        Vector3 controllerMoveVec = _controller.position - _lastControllerPos;
        controllerMoveVec.y = 0;
        float vecLength = controllerMoveVec.magnitude;

        if (count_cooltime <= 0)
        {
            if (vecLength > _shotBorder)
            {
                ShotCannon();
                count_cooltime = _coolframe;
            }
        }

        _lastControllerPos = _controller.position;

        _last_cannon_transform = cannon_body_transform;
        keepTransform.Add(_last_cannon_transform);

        if (keepTransform.Count >= _lateframe)
        {
            keepTransform.RemoveAt(0);
        }

        count_cooltime -= 1;
    }

    void ShotCannon()
    {

        Transform beforeTransform = keepTransform[0];

        Debug.Log(cannon_body_transform.position.x);

        GameObject bullet = Instantiate(bullet_prefab, fixedcannon_body_transform.position, Quaternion.identity);

        Bullet bulletState = bullet.GetComponent<Bullet>();
        bullet.transform.rotation = fixedcannon_body_transform.rotation;


        bulletState._speed = _shotSpeed;

        //Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        //bulletRb.AddForce(beforeTransform.forward * 400);
        Destroy(bullet, 3.0f);
    }
}
