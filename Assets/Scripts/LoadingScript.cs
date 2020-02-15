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
        AsyncOperation Loading = SceneManager.LoadSceneAsync("Game");
        float progress;
        Loading.allowSceneActivation = false;
        while (Loading.progress < .9f)
        {
            progress = Mathf.Clamp01(Loading.progress / .9f);
            Slider.GetComponent<Slider>().value = progress;
            yield return 0;
        }
        progress = Mathf.Clamp01(Loading.progress / .9f);
        Slider.GetComponent<Slider>().value = progress;
        animator.SetTrigger("FadeOutTrigger");
        yield return new WaitForSeconds(1);
        Loading.allowSceneActivation = true;
    }

}
