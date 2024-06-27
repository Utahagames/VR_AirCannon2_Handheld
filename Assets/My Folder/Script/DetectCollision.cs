using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    [Tooltip("Left=0 Right=1")]
    [SerializeField] int _mycontroller;

    [SerializeField] OVRInput.Controller controllerType;

    [SerializeField] Life _life;
  
    [SerializeField] AudioClip sound_Damage;
    AudioSource audioSource;

    public enum Players
    {
        Left,
        Right
    }

    Players _myplayer;

    //InputDevice device;
    //HapticCapabilities capabilities;

    // Start is called before the first frame update
    void Start()
    {
        _myplayer = (Players)_mycontroller;

        audioSource = GetComponent<AudioSource>();

        /*
        device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        
        if (device.TryGetHapticCapabilities(out capabilities))
            if (capabilities.supportsImpulse)
                device.SendHapticImpulse(0, 0.5f, 1.0f);
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            HitEnemyShot();
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        GameObject Hitobject = other.gameObject;

        if (Hitobject.tag == "Bullet_Left" && _myplayer == Players.Right)
        {
            Hitobject.GetComponent<Bullet>().Hit();

            HitEnemyShot();
        }
        else if (Hitobject.tag == "Bullet_Right" && _myplayer == Players.Left)
        {
            Hitobject.GetComponent<Bullet>().Hit();

            HitEnemyShot();
        }
    }

    void HitEnemyShot()
    {
        Debug.Log("Hit");

        if (!_life.IsDead)
        {
            audioSource.PlayOneShot(sound_Damage);
            _life.Damaged(controllerType);
        }

        /*
        if (device.TryGetHapticCapabilities(out capabilities))
            if (capabilities.supportsImpulse)
                device.SendHapticImpulse(0, 0.5f, 1.0f);
        */
    }

    

}
