using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public Animator animator;

    public void Back() {
        animator.SetTrigger("SettingsTrigger");
    }
}
