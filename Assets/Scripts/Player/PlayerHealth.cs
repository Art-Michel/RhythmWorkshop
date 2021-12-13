using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerHealth : LocalManager<PlayerHealth>
{
    CharacterController _charaCon;
    [SerializeField] CinemachineImpulseListener _vcamImpulseListener;

    public float PlayerHP { get; private set; }
    float _maxHP = 3;

    [SerializeField] Image _hpBar;
    [SerializeField] VolumeProfile volume;

    bool _isInvulnerable;

    float _healthRegenCooldown;
    float _healthRegenSpeed = 0.8f;

    private void Start()
    {
        PlayerHP = _maxHP;
        _healthRegenCooldown = 0;
        _isInvulnerable = false;
        _charaCon = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PassiveRegeneration();
    }

    public void TakeDamage(float damageAmount)
    {
        if (!_isInvulnerable)
        {
            PlayerHP -= damageAmount;
            UpdateHPBar();
            _healthRegenCooldown = 2;
            StartCoroutine("HandleInvulnerability");
            SoundManager.Instance.PlayplayerGetsHit();
        }
    }

    public void TakeDamage(float damageAmount, float knockbackAmount, Vector2 knockbackDirection)
    {
        TakeDamage(damageAmount);
        _charaCon.Move(knockbackDirection * knockbackAmount);
    }

    public void Heal(float healAmount)
    {
        PlayerHP = Mathf.Clamp(PlayerHP += healAmount, 0, _maxHP);
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
            PlayerHP = Mathf.Clamp(PlayerHP += _healthRegenSpeed * Time.deltaTime, 0, _maxHP);
            UpdateHPBar();
        }
        else
            _healthRegenCooldown -= Time.deltaTime;
    }

    private IEnumerator HandleInvulnerability()
    {
        _isInvulnerable = true;

        yield return new WaitForSeconds(0.2f);
        _vcamImpulseListener.enabled = false;

        //Invulnerability Window of total 1.5sec
        yield return new WaitForSeconds(1.3f);
        _vcamImpulseListener.enabled = true;
        _isInvulnerable = false;

        yield return null;
    }
}
