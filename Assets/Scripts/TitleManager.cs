using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Sample");
    }
}