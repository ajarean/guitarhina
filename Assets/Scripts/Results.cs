using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI scoreText;
    [SerializeField]TextMeshProUGUI perfectText;
    [SerializeField] TextMeshProUGUI greatText;
    [SerializeField] TextMeshProUGUI badText;
    [SerializeField] TextMeshProUGUI missText;
    [SerializeField] TextMeshProUGUI comboText;

    private void OnEnable()
    {
        scoreText.text = GManager.instance.score.ToString();
        perfectText.text = GManager.instance.perfect.ToString();
        greatText.text = GManager.instance.great.ToString();
        badText.text = GManager.instance.bad.ToString();
        missText.text = GManager.instance.miss.ToString();
        comboText.text = GManager.instance.maxCombo.ToString();
    }

    public void Retry()
    {
        GManager.instance.perfect = 0;
        GManager.instance.great = 0;
        GManager.instance.bad = 0;
        GManager.instance.miss = 0;
        GManager.instance.maxScore = 0;
        GManager.instance.ratioScore = 0;
        GManager.instance.score = 0;
        GManager.instance.combo = 0;
        GManager.instance.maxCombo = 0;
        SceneManager.LoadScene("Sample");
    }
}