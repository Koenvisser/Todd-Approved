using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Animator animator;
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

    private IEnumerator Quit2() {
        animator.SetTrigger("FadeOutTrigger");
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
