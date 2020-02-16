 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public GameObject Slider;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadGame());
    }
    private IEnumerator LoadGame()
    {
        //loads the main game
        yield return new WaitForSeconds(.1f);
        AsyncOperation Loading = SceneManager.LoadSceneAsync("Game");
        Loading.allowSceneActivation = false;
        while (Loading.progress < .9f)
        {
            Slider.GetComponent<Slider>().value = Mathf.Clamp01(Loading.progress / .9f);
            yield return 0;
        }
        Slider.GetComponent<Slider>().value = Mathf.Clamp01(Loading.progress / .9f);
        animator.SetTrigger("FadeOutTrigger");
        yield return new WaitForSeconds(1);
        Loading.allowSceneActivation = true;
    }

}
