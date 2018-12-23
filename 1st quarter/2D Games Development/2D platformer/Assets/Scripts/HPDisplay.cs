using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Game.Controllers;
using Game.Effects;
[RequireComponent(typeof(HealthController))]
public class HPDisplay : MonoBehaviour
{

    private HealthController _hpController;
    [SerializeField]
    private Image _healthBar;
    [SerializeField]
    private Image _healthBarBG;
    private FadeEffect _fade;
    private Color _healthBarBGstartColor;
    private Color _healthBarstartColor;
    
    private const float  _waitToHideBars = 3;
    
    private const float _fadeBarsTime = 3;
    Color hideColor;
    // Use this for initialization
    void Start()
    {
        _fade = new FadeEffect();
        _hpController = GetComponent<HealthController>();
        _healthBarstartColor = _healthBar.color;
        _healthBarBGstartColor = _healthBarBG.color;
        _hpController.OnHpChange += ChangeHp;
        
        hideColor = new Color(0, 0, 0, 0);
        HideBars();
    }

    void ChangeHp(int value)
    {
        
        ShowHpBar();
        if (value != 0)
        {
            _healthBar.fillAmount = (float)value / (float)_hpController.StartHp;
        }
        StopAllCoroutines();
        StartCoroutine(WaitToFade(_waitToHideBars));

    }
    void ShowHpBar()
    {
        
        _healthBar.color = _healthBarstartColor;
        _healthBarBG.color = _healthBarBGstartColor;

    }
    
    IEnumerator FadeOutHp(float fadeTime)
    {

        float t = 0f;
        while (t <= fadeTime)
        {

            _healthBar.color = Color.Lerp(_healthBar.color, hideColor, t / fadeTime);
            _healthBarBG.color = Color.Lerp(_healthBarBG.color, hideColor, t / fadeTime);
            t += Time.deltaTime;
            yield return null;

        }

        _healthBar.color = hideColor;
        _healthBarBG.color = hideColor;
    }
    IEnumerator WaitToFade(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        StartCoroutine(FadeOutHp(_fadeBarsTime));
    }
    void HideBars()
    {
        StopAllCoroutines();
        _healthBar.color = hideColor;
        _healthBarBG.color = hideColor;
    }


}
