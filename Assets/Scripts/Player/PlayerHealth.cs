using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float PlayerHP { get; private set; }
    float _maxHP = 3;

    [SerializeField] Image _hpBar;
    [SerializeField] VolumeProfile volume;

    float _healthRegenCooldown;
    float _healthRegenSpeed = 0.8f;

    private void Start()
    {
        PlayerHP = _maxHP;
        _healthRegenCooldown = 0;
    }

    private void Update()
    {
        if (_healthRegenCooldown <= 0 && PlayerHP < _maxHP)
        {
            PlayerHP += _healthRegenSpeed * Time.deltaTime;
            PlayerHP = Mathf.Clamp(PlayerHP, 0, _maxHP);
            UpdateHPBar();
        }
        else
            _healthRegenCooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
            TakeDamage(1);
    }

    public void TakeDamage(float damageAmount)
    {
        PlayerHP -= damageAmount;
        UpdateHPBar();
        _healthRegenCooldown = 2;
    }

    public void Heal(float healAmount)
    {
        PlayerHP += healAmount;
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        _hpBar.fillAmount = PlayerHP / _maxHP;

        Vignette vignette;
        if (volume.TryGet<Vignette>(out vignette))
            vignette.intensity.Override(-PlayerHP / _maxHP + 1);
    }


}
