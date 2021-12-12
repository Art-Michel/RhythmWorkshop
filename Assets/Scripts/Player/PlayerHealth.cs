using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerHealth : LocalManager<PlayerHealth>
{
    CharacterController _charaCon;

    public float PlayerHP { get; private set; }
    float _maxHP = 3;

    [SerializeField] Image _hpBar;
    [SerializeField] VolumeProfile volume;

    bool _isInvulnerable;
    float _invulnerabilityCooldown;
    float _invulnerabilityWindow = 1.5f;

    float _healthRegenCooldown;
    float _healthRegenSpeed = 0.8f;

    private void Start()
    {
        PlayerHP = _maxHP;
        _healthRegenCooldown = 0;
        _invulnerabilityCooldown = 0;
        _isInvulnerable = false;
        _charaCon = GetComponent<CharacterController>();
    }

    private void Update()
    {
        VulnerabilityCooldown();
        PassiveRegeneration();
    }

    private void VulnerabilityCooldown()
    {
        if (_invulnerabilityCooldown > 0)
            _invulnerabilityCooldown -= Time.deltaTime;
    }

    public void TakeDamage(float damageAmount)
    {
        if (_invulnerabilityCooldown <= 0)
        {
            PlayerHP -= damageAmount;
            UpdateHPBar();
            _healthRegenCooldown = 2;
            _invulnerabilityCooldown = _invulnerabilityWindow;
        }
    }

    public void TakeDamage(float damageAmount, float knockbackAmount, Vector2 knockbackDirection)
    {
        TakeDamage(damageAmount);
        _charaCon.Move(knockbackDirection * knockbackAmount);
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
            vignette.intensity.Override(Mathf.InverseLerp(3, 0, PlayerHP));
    }

    private void PassiveRegeneration()
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
}
