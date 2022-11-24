using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownBox : MonoBehaviour
{
    string DROPDOWN_KEY = "DROPDOWN_KEY";

    int currentOption;
    TMP_Dropdown options;

    List<string> optionList = new List<string>();

    private void Awake() {
        if (PlayerPrefs.HasKey(DROPDOWN_KEY) == false) currentOption = 0;
        else currentOption = PlayerPrefs.GetInt(DROPDOWN_KEY);
    }

    // Start is called before the first frame update
    void Start()
    {
        options = this.GetComponent<TMP_Dropdown>();

        options.ClearOptions();

        optionList.Add("daum.net");
        optionList.Add("gmail.com");
        optionList.Add("hanmail.net");
        optionList.Add("naver.com");
        optionList.Add("nate.com");
        optionList.Add("직접 입력");

        options.AddOptions(optionList);

        options.value = currentOption;

        options.onValueChanged.AddListener(delegate { setDropDown(options.value); });
        setDropDown(currentOption);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDropDown(int option)
    {
        PlayerPrefs.SetInt(DROPDOWN_KEY, option);

        // option 관련 동작
        Debug.Log("current option : " + option);
    }
}
