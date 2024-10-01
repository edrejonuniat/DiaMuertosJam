using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private AudioSource sfxPlayer;
    [SerializeField] private Animator animator;
    private const string CLICK_TRIGGER = "Click";

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Singleton.OnClick();
        sfxPlayer.Play();
        animator.SetTrigger(CLICK_TRIGGER);
    }
}
