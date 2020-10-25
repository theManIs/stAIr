using Coffee.UIEffects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OutlineButton : Button
{
    UIShadow uiShadow;

    protected override void Awake()
    {
        base.Awake();
        uiShadow = GetComponentInChildren<UIShadow>();
        SetAlphaImmediately(0);
    }

    Coroutine alphaCor;
    float transitionSpeed = 0.1f;

    private void SetAlpha(float alpha)
    {
        if (alphaCor!= null)
            StopCoroutine(alphaCor);

        alphaCor = StartCoroutine(SetAlphaRaw(alpha));
    }

    private IEnumerator SetAlphaRaw(float alpha)
    {
        var color = uiShadow.effectColor;
        while (color.a != alpha)
        {
            color.a = Mathf.MoveTowards(color.a, alpha, transitionSpeed);
            uiShadow.effectColor = color;
            yield return null;
        }
    }

    private void SetAlphaImmediately(float alpha)
    {
        var color = uiShadow.effectColor;
        color.a = alpha;
        uiShadow.effectColor = color;
    }

    Color effectColorOriginal;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if (interactable)
            SetAlpha(0.6f);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        SetAlpha(0);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (interactable)
            SetAlpha(0.2f);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (interactable)
            SetAlpha(0.6f);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        SetAlphaImmediately(0);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        SetAlphaImmediately(0);
    }
}