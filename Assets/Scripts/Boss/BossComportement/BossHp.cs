using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : LocalManager<BossHp>
{
    public float BossHealthPoints { get; private set; }
    [SerializeField] float _maxHP = 300;

    [SerializeField] Image _hpBar;

    private void Start()
    {
        BossHealthPoints = _maxHP;
    }

    public void TakeDamage(float damageAmount)
    {
        BossHealthPoints -= damageAmount;
        UpdateHPBar();
        SoundManager.Instance.PlaybossGruntLight();
    }

    private void UpdateHPBar()
    {
        //_hpBar.fillAmount = BossHealthPoints / _maxHP;
    }
}
