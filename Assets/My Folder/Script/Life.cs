using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Life : MonoBehaviour
{
    [SerializeField] private int _maxHeart;
    [SerializeField] float _respawntime = 5.0f;
    public int remainingHeart { get; set; }
    public bool IsDead { get; set; } = false;

    public event Action OnDamaged;
    public event Action OnRespawn;

    private Coroutine _vibrationCoroutine = null;

    void Start()
    {
        remainingHeart = _maxHeart;
    }


    public void Damaged(OVRInput.Controller controller)
    {
        remainingHeart -= 1;
        OnDamaged?.Invoke();

        if (_vibrationCoroutine != null)
        {
            StopCoroutine(_vibrationCoroutine);
        }
        if (remainingHeart <= 0)
        {
            IsDead = true;
            _vibrationCoroutine = StartCoroutine(Respawn(controller));
        }
        else
        {
            _vibrationCoroutine = StartCoroutine(Vibrate(controller, 0.5f));
        }
    }

    private IEnumerator Respawn(OVRInput.Controller controller)
    {
        /*
        for(int i = 0;i < 2; i++)
        {
            StartCoroutine(Vibrate(controller, _respawntime / 2f));
            //指定された時間待つ
            yield return new WaitForSeconds(_respawntime / 2f);
        }
        */

        float timeCount = _respawntime;
        while (timeCount > 0)
        {
            timeCount -= Time.deltaTime;
            OVRInput.SetControllerVibration(10, 10, controller);
            yield return null;
        }
        OVRInput.SetControllerVibration(0, 0, controller);

        remainingHeart = _maxHeart;
        IsDead = false;

        OnRespawn?.Invoke();
    }

    /// <summary>
    /// Oculus Quest(やQuest2)のコントローラーを振動させる
    /// </summary>
    public static IEnumerator Vibrate(OVRInput.Controller controller, float duration = 0.1f, float frequency = 10.0f, float amplitude = 10.0f)
    {
        //コントローラーを振動させる
        OVRInput.SetControllerVibration(frequency, amplitude, controller);

        //指定された時間待つ
        yield return new WaitForSeconds(duration);

        //コントローラーの振動を止める
        OVRInput.SetControllerVibration(0, 0, controller);
    }

    public void ResetLife(OVRInput.Controller controller)
    {
        StopCoroutine(Respawn(controller));

        /*
        for(int i = 0;i < 2; i++)
        {
            StartCoroutine(Vibrate(controller, _respawntime / 2f));
            //指定された時間待つ
            yield return new WaitForSeconds(_respawntime / 2f);
        }
        */

        OVRInput.SetControllerVibration(0, 0, controller);

        remainingHeart = _maxHeart;
        IsDead = false;

        OnRespawn?.Invoke();
    }
}
