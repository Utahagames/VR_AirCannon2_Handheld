using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed { get;  set; } = 0.0f;
    public float _accel { get; set; } = -0.0f;	


    [SerializeField] GameObject Effect_Damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        _speed += _accel * Time.deltaTime;
        Debug.Log(_speed);
    }

    public void Hit()
    {
        Instantiate(Effect_Damage, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
