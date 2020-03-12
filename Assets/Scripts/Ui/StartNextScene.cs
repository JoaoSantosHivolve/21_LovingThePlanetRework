using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class StartNextScene : MonoBehaviour
{
    public Animator animator;
    public AudioSource sound;
    private const string ButtonPressed = "ButtonPressed";

    public void StartScene_OnClick()
    {
        animator.SetBool(ButtonPressed, true);

        // Play Sound
        sound.Play();
    }
}