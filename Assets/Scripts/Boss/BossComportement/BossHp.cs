using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : LocalManager<BossHp>
{
    public float BossHealthPoints { get; private set; }
    public float oldBossHealthPoints;
    [SerializeField] float speed;
    float chrono = 0;
    public bool tookDamage;

    [SerializeField] float _maxHP = 300;

    [SerializeField] Image _hpBar;
    [SerializeField] Image _hpDamageBar;
    [SerializeField] Animator hitBoss;

    private void Start()
    {
        BossHealthPoints = _maxHP;
        oldBossHealthPoints = BossHealthPoints;
    }

    public void TakeDamage(float damageAmount)
    {
        BossHealthPoints -= damageAmount;
        UpdateHPBar();
        hitBoss.SetTrigger("hitBoss");
        if (BossHealthPoints <= 0)
        {
            GameOver();
        }
        tookDamage = true;
        SoundManager.Instance.PlaybossGruntLight();
    }

    void GameOver()
    {
        ScoreManager.Instance.DisplayWinScreen();
        gameObject.SetActive(false);
    }

    private void UpdateHPBar()
    {
        _hpBar.fillAmount = BossHealthPoints / _maxHP;
    }

    private void Update()
    {
        if (tookDamage == true)
        {
            chrono += Time.deltaTime;
            if (chrono >= 0.5f)
            {
                chrono = 0f;
                tookDamage = false;
            }
        }

        if (tookDamage == false)
        {
            float timer = 0f;
            timer += Time.deltaTime;
            oldBossHealthPoints = Mathf.Lerp(oldBossHealthPoints, BossHealthPoints, timer);
            _hpDamageBar.fillAmount = oldBossHealthPoints / _maxHP;
        }
    }
}
