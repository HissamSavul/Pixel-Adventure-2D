using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image img;
    [SerializeField] private Sprite defaultSprite, pressedSprite;
    [SerializeField] private AudioClip compressedImgClip, uncompressedImgClip;
    [SerializeField] private AudioSource audioSource;

    public void OnPointerDown(PointerEventData eventData)
    {
        img.sprite = pressedSprite;
        audioSource.PlayOneShot(compressedImgClip);
        audioSource.volume = 0.1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        img.sprite = defaultSprite;
        audioSource.PlayOneShot(uncompressedImgClip);
        audioSource.volume = 0.1f;
    }
}
