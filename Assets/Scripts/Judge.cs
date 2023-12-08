using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviour
{
    [SerializeField] private GameObject[] MessageObj;
    [SerializeField] NotesManager notesManager;

    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI HPText;
    [SerializeField] GameObject finish;
    [SerializeField] GameObject start;

    new AudioSource audio;
    [SerializeField] AudioClip hitSound;

    float endTime = 0;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        endTime = notesManager.NotesTime[notesManager.NotesTime.Count-1];
        GManager.instance.hp = 100;
    }
    void Update()
    {
        if (GManager.instance.Start)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (notesManager.LaneNum[0] == 0)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 0)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (notesManager.LaneNum[0] == 1)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)),0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 1)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (notesManager.LaneNum[0] == 2)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)),0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 2)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (notesManager.LaneNum[0] == 3)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)),0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 3)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if(GManager.instance.combo > GManager.instance.maxCombo){
                GManager.instance.maxCombo = GManager.instance.combo;
            }
            if(!GManager.instance.Start){
                start.SetActive(true);
            }
            else{
                start.SetActive(false);
            }
            if(Time.time > endTime + GManager.instance.StartTime){
                finish.SetActive(true);
                Invoke("ResultScene", 3f);
                return;
            }
            if (Time.time > notesManager.NotesTime[0] + 0.2f + GManager.instance.StartTime)
            {
                message(3);
                deleteData(0);
                Debug.Log("Miss");
                GManager.instance.miss++;
                if(GManager.instance.hp > 0){
                    GManager.instance.hp -= 5;
                }
                GManager.instance.combo = 0;
            }
        }
    }
    void Judgement(float timeLag,int numOffset)
    {
        audio.PlayOneShot(hitSound);
        if (timeLag <= 0.05)
        {
            Debug.Log("Perfect");
            message(0);
            if(GManager.instance.hp <= 100){
                GManager.instance.hp += 2;
            }
            GManager.instance.ratioScore += 5;
            GManager.instance.perfect++;
            GManager.instance.combo++;
            deleteData(numOffset);
        }
        else
        {
            if (timeLag <= 0.08)
            {
                Debug.Log("Great");
                message(1);
                GManager.instance.ratioScore += 3;
                GManager.instance.great++;
                if(GManager.instance.hp <= 100){
                    GManager.instance.hp += 2;
                }
                GManager.instance.combo++;
                deleteData(numOffset);
            }
            else
            {
                if (timeLag <= 0.10)
                {
                    Debug.Log("Bad");
                    message(2);
                    GManager.instance.ratioScore += 1;
                    GManager.instance.bad++;
                    GManager.instance.combo = 0;
                    deleteData(numOffset);
                }
            }
        }
    }
    float GetABS(float num)
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }
    void deleteData(int numOffset)
    {
        notesManager.NotesTime.RemoveAt(numOffset);
        notesManager.LaneNum.RemoveAt(numOffset);
        notesManager.NoteType.RemoveAt(numOffset);
        GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);
        comboText.text = GManager.instance.combo.ToString();
        scoreText.text = GManager.instance.score.ToString();
        HPText.text = GManager.instance.hp.ToString();
    }

    void message(int judge)
    {
        Instantiate(MessageObj[judge],new Vector3(notesManager.LaneNum[0]-1.5f,0.76f,0.15f),Quaternion.Euler(45,0,0));
    }

    void ResultScene(){
        SceneManager.LoadScene("Result");
    }
}