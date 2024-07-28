using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerHealthVisual : MonoBehaviour
{
    [SerializeField] private Image DamageScreenBorder;
    [SerializeField] private Image DamageScreen;
    [SerializeField] private HealthController PlayerHealth;
    [SerializeField] private TMP_Text HealthText;
    [SerializeField] private Image PlayerHealthImage;
    [SerializeField] private float ScreenDamageStrenght;
    [SerializeField] private float RegenCooldown;
    [SerializeField] private float  RegenSpeed;
    private float RegenStrenght;
    private float Regentime;
    private void Reset()
    {
        PlayerHealth.onDamageTakenEvent.AddListener(SetScreenDamage);
        PlayerHealth.onLifeChangeEvent.AddListener(setTextHealth);
        PlayerHealth.onLifeChangeEvent.AddListener(SetBorderDamage);
    }
    private void Start()
    {
        setTextHealth();
        SetBorderDamage();
    }

    private void Update()
    {
        Regentime += Time.deltaTime * RegenSpeed;
        if(Regentime >= RegenCooldown && DamageScreen.color.a > 0)
        {
            ChangeScreenTransparency(RegenStrenght);
            if(RegenStrenght > 0)
            {
                RegenStrenght -= Time.deltaTime* RegenSpeed;
                if(RegenStrenght < 0) { RegenStrenght = 0; }
            }
        }
    }
    public void setTextHealth()
    {
        HealthText.text = PlayerHealth.Health.ToString();
        PlayerHealthImage.fillAmount = PlayerHealth.Health/ PlayerHealth.GetMaxiHealth();
    }

    public void SetScreenDamage()
    {
        Regentime = 0;
        RegenStrenght = ScreenDamageStrenght;
        ChangeScreenTransparency(ScreenDamageStrenght);
    }
   private void ChangeScreenTransparency(float strenght)
    {
        float transparencyBorder = strenght;
        Color ScreenColor = Color.red;
        ScreenColor.a = transparencyBorder;
        DamageScreen.color = ScreenColor;
    }


    public void SetBorderDamage()
    {
        float transparencyBorder = 1 - (PlayerHealth.Health / PlayerHealth.GetMaxiHealth());
        Color bordercolor = Color.white;
        bordercolor.a = transparencyBorder;
        DamageScreenBorder.color = bordercolor;
    }

}
