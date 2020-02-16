using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Animator ToddAnimator;
    public Animator MenuAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Play()
    {

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
