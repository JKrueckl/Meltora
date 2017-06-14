using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBarManager : MonoBehaviour {

    public Button _Skills;
    public Button _PlayerInfo;
    public Button _InventoryBags;
    public Button _Settings;

    private Dictionary<string, bool> _WindowManager = new Dictionary<string, bool>();

	// Use this for initialization
	void Start () {

        _Skills = _Skills.GetComponent<Button>();
        _PlayerInfo = _PlayerInfo.GetComponent<Button>();
        _InventoryBags = _InventoryBags.GetComponent<Button>();
        _Settings = _Settings.GetComponent<Button>();

        _Skills.onClick.AddListener(Skills_OnClick);
        _PlayerInfo.onClick.AddListener(PlayerInfo_OnClick);
        _InventoryBags.onClick.AddListener(InventoryBags_OnClick);
        _Settings.onClick.AddListener(Settings_OnClick);

        _WindowManager.Add("SkillsWindow", false);
        _WindowManager.Add("PlayerInfoWindow", false);
        _WindowManager.Add("InventoryBagsWindow", false);
        _WindowManager.Add("SettingsWindow", false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Skills_OnClick()
    {
        Debug.Log("Clicked Skills");

        _WindowManager["SkillsWindow"] = true;       
    }

    void PlayerInfo_OnClick()
    {
        Debug.Log("Clicked PlayerInfo");

        _WindowManager["PlayerInfoWindow"] = true;
    }

    void InventoryBags_OnClick()
    {
        Debug.Log("Clicked InventoryBags");

        _WindowManager["InventoryBagsWindow"] = true;
    }

    void Settings_OnClick()
    {
        Debug.Log("Clicked Settings");

        _WindowManager["SettingsWindow"] = true;
    }
}
