using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class View : MonoBehaviour
{
    private Animator _animator;
    private float initXScale;
    
    [SerializedDictionary("Sprite Name", "Sprite Renderer")]
    public SerializedDictionary<BodyPart, SpriteRenderer[]> bodyParts;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        EventManager.Subscribe(EventName.UpdateHAxis, UpdateHAxis);
        EventManager.Subscribe(EventName.UpdateVAxis, UpdateVAxis);
        EventManager.Subscribe(EventName.ChangeCloth, ChangeCloth);
        initXScale = transform.localScale.x;
    }

    private void UpdateHAxis(params object[] parameters)
    {
        var axis = (float)parameters[0];
        _animator.SetFloat("Horizontal", axis);

        transform.localScale =
            new Vector3(axis >= 0 ? initXScale : -initXScale, transform.localScale.y, transform.localScale.z);
    }

    private void UpdateVAxis(params object[] parameters)
    {
        _animator.SetFloat("Vertical", (float)parameters[0]);
    }

    private void ChangeCloth(params object[] parameters)
    {
        var renderers = bodyParts[(BodyPart)parameters[0]];
        var sprites = (Sprite[])parameters[1];

        for (var i = 0; i < sprites.Length; i++)
        {
            renderers[i].sprite = sprites[i];
        }
    }
}
