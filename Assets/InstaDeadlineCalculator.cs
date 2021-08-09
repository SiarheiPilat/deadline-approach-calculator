using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstaDeadlineCalculator : MonoBehaviour
{
    public TextMeshProUGUI TimeNow, DayResult, TimeResult;
    public TMP_InputField Days, Hours, Minutes;
    public GameObject ResultsPanelUI;

    private void Start()
    {
        ResultsPanelUI.SetActive(false);
        Days.text = "0";
        Hours.text = Days.text;
        Minutes.text = Days.text;
        GetCurrentTime();
    }

    void GetCurrentTime()
    {
        TimeNow.text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
    }

    public void ui_OnCalculateButtonPressed()
    {
        if (Days.text != "" || Hours.text != "" || Minutes.text != "")  // this is OK because TMP input settings force integers
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now.AddDays(double.Parse(Days.text)).AddHours(double.Parse(Hours.text)).AddMinutes(double.Parse(Minutes.text));
            DayResult.text = dateTime.ToLongDateString();
            TimeResult.text = dateTime.ToLongTimeString();
            ResultsPanelUI.SetActive(true);
        }
    }

    public void ui_OnAgainButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
