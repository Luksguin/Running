using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class PowerUpManager : Singleton<PowerUpManager>
{
    public PlayerController playerController;

    [Header("PowerUpVelocity")]
    public float forcePowerUpVelocity;

    [Header("PowerUpInvencible")]
    public Color startColor;
    public Color newColor;

    [Header("PowerUpFly")]
    public Transform playerTransform;
    public Vector3 startHeigth;

    [Header("PowerUpCoin")]
    public GameObject coinCollector;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {

    }

    #region VELOCITY
    public void InitPowerUpVelocity()
    {
        playerController.currentVelocity *= forcePowerUpVelocity;
    }

    public void EndPowerUpVelocity()
    {
        playerController.currentVelocity = playerController.playerVelocity;
    }
    #endregion

    #region INVENCIBLE
    private void ChangeColor(Color newColor)
    {
        playerController.playerRenderer.material.SetColor("_Color", newColor);
    }

    public void InitPowerUpInvencible()
    {
        playerController.invencible = true;
        ChangeColor(newColor);
    }

    public void EndPowerUpInvencible()
    {
        playerController.invencible = false;
        ChangeColor(startColor);
    }
    #endregion

    #region FLY
    public void InitPowerUpFly(float amount, float duration, float animationDuration, Ease ease)
    {
        playerTransform.transform.DOMoveY(startHeigth.y + amount, animationDuration).SetEase(ease);
    }

    public void EndPowerUpFly(float animationDuration, Ease ease)
    {
        playerTransform.transform.DOMoveY(startHeigth.y, animationDuration).SetEase(ease);
    }
    #endregion

    #region COIN
    public void ChangeSizeCoinCollector(float amount)
    {
        coinCollector.transform.DOScaleX(amount, .1f);
    }
    #endregion
}
