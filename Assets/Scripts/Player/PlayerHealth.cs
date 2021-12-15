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
    [SerializeField] GameObject lostMenu;
    [SerializeField] VolumeProfile volume;
    [SerializeField] Animator animInv;

    bool _isInvulnerable;

    float _healthRegenCooldown;
    float _healthRegenSpeed = 0.5f;

    private void Start()
    {
        PlayerHP = _maxHP;
        _healthRegenCooldown = 0;
        _isInvulnerable = false;
        _charaCon = GetComponent<CharacterController>();
        UpdateHPBar();
    }

    private void Update()
    {
        PassiveRegeneration();

        if (PlayerHP <= 0)
        {
            lostMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (!_isInvulnerable)
        {
            PlayerHP -= damageAmount;
            UpdateHPBar();
            SoundManager.Instance.PlayplayerGetsHit();
            _healthRegenCooldown = 2;
            ScoreManager.Instance.GetHit();
            StartCoroutine("HandleInvulnerability");
            if (PlayerHP <= 0)
                GameOver();
        }
    }

    public void TakeDamage(float damageAmount, float knockbackAmount, Vector2 knockbackDirection)
    {
        _charaCon.Move(knockbackDirection * knockbackAmount);
        TakeDamage(damageAmount);
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
        animInv.SetBool("isInvincible", true);

        yield return new WaitForSeconds(0.2f);
        _vcamImpulseListener.enabled = false;

        //Invulnerability Window of total 1sec
        yield return new WaitForSeconds(0.8f);
        _vcamImpulseListener.enabled = true;
        _isInvulnerable = false;
        animInv.SetBool("isInvincible", false);

        yield return null;
    }

    void GameOver()
    {
        ScoreManager.Instance.DisplayGameOverScreen();
        gameObject.SetActive(false);
    }
}
