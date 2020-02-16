using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Animator ToddAnimator;
    public Animator MenuAnimator;

    public void Play()
    {
        StartCoroutine(Play2());
    }

    private IEnumerator Play2() {
        MenuAnimator.SetTrigger("PlayTrigger");
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
    public void Quit()
    {
        StartCoroutine(Quit2());
    }

    public void Settings()
    {
        MenuAnimator.SetTrigger("MenuTrigger");
    }

    private IEnumerator Quit2() {
        ToddAnimator.SetTrigger("FadeOutTrigger");
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
