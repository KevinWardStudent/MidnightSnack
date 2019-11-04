using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject clickFX;
    public GameObject hoverFX;
    public GameObject startButton;
    public GameObject extrasButton;
    public GameObject optionsButton;
    public GameObject extrasPanel;
    public GameObject quitButton;
    public GameObject transAnim;

    /*private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Instantiate(clickFX, transform.position, transform.rotation);
        }
    }*/

    public void StartGame()
    {
        StartCoroutine(startDelay());
    }

    public void Extras()
    {
        StartCoroutine(extrasDelay());
    }

    public void backFromExtras()
    {
        extrasPanel.SetActive(false);
        transAnim.SetActive(false);
    }

    public void Options()
    {
        Instantiate(clickFX, optionsButton.transform.position, optionsButton.transform.rotation);
    }

    public void QuitGame()
    {
        //StartCoroutine(quitDelay());
        Instantiate(clickFX, quitButton.transform.position, quitButton.transform.rotation);
        Application.Quit();
    }

    public void StartOnHoverFX()
    {
        Instantiate(hoverFX, startButton.transform.position, startButton.transform.rotation);
    }

    public void OptionsOnHoverFX()
    {
        Instantiate(hoverFX, optionsButton.transform.position, optionsButton.transform.rotation);
    }

    public void ExtrasOnHoverFX()
    {
        Instantiate(hoverFX, extrasButton.transform.position, extrasButton.transform.rotation);
    }

    public void QuitOnHoverFX()
    {
        Instantiate(hoverFX, quitButton.transform.position, quitButton.transform.rotation);
    }

    IEnumerator startDelay()
    {
        Instantiate(clickFX, startButton.transform.position, startButton.transform.rotation);
        transAnim.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene(1);
    }

    IEnumerator extrasDelay()
    {
        Instantiate(clickFX, extrasButton.transform.position, extrasButton.transform.rotation);
        transAnim.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        extrasPanel.SetActive(true);
        //SceneManager.LoadScene(1);
    }

    IEnumerator quitDelay()
    {
        Instantiate(clickFX, extrasButton.transform.position, extrasButton.transform.rotation);
        transAnim.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        Application.Quit();
    }
}