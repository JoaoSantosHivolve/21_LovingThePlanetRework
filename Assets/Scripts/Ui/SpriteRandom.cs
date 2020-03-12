using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class SpriteRandom : MonoBehaviour
{
    public Sprite randomImage;
    public Sprite[] images;
    private Image m_Image;

    private void Start()
    {
        m_Image = GetComponent<Image>();
        int num = UnityEngine.Random.Range(0, images.Length);
        randomImage = images[num];
        m_Image.sprite = randomImage;
        m_Image.color = Color.white;
    }
}