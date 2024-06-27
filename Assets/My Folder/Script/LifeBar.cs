using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> Life_hearts;
    [SerializeField] private Life _life;

    private void Awake()
    {
        _life.OnDamaged += Damaged;
        _life.OnRespawn += Respawn;
    }

    private void Damaged()
    {
        Color Color_Life = Life_hearts[_life.remainingHeart].color;
        Color_Life.a = 0.0f;
        Life_hearts[_life.remainingHeart].color = Color_Life;
    }

    private void Respawn()
    {
        foreach (var item in Life_hearts)
        {
            Color Color_Life = item.color;
            Color_Life.a = 1f;
            item.color = Color_Life;
        }
    }

}
