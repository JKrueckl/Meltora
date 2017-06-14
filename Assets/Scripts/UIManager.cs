using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Dictionary<string, GameObject> _DicUIWindows = new Dictionary<string, GameObject>();
    public GameObject[] _UIWindows;

    #region HotBar Buttons

    public Button _Skills;
    public Button _PlayerInfo;
    public Button _InventoryBags;
    public Button _Settings;

    #endregion

    #region PlayerInfoWindow Buttons

    public Button _ExitPlayerInfo;
    public Button _UpgradeATK;
    public Button _UpgradeSpeed;
    public Button _UpgradeDEF;
    public Button _UpgradeHP;

    #endregion

    #region InventorySelectWindow Buttons

    public Button _ExitInventorySelect;

    #endregion

    // Use this for initialization
    void Start () {

        foreach(GameObject UIWindow in _UIWindows)
        {
            UIWindow.SetActive(false);

            _DicUIWindows.Add(UIWindow.name, UIWindow);

            Debug.Log("Hiding : " + UIWindow.name);
        }

        HotBarInits();
        PlayerInfoWindowInits();
        InventorySelectWindowInits();
    }

    void HotBarInits()
    {
        _Skills = _Skills.GetComponent<Button>();
        _PlayerInfo = _PlayerInfo.GetComponent<Button>();
        _InventoryBags = _InventoryBags.GetComponent<Button>();
        _Settings = _Settings.GetComponent<Button>();

        _Skills.onClick.AddListener(Skills_OnClick);
        _PlayerInfo.onClick.AddListener(PlayerInfo_OnClick);
        _InventoryBags.onClick.AddListener(InventoryBags_OnClick);
        _Settings.onClick.AddListener(Settings_OnClick);
    }

    void PlayerInfoWindowInits()
    {
        _ExitPlayerInfo.GetComponent<Button>();
        _UpgradeATK.GetComponent<Button>();
        _UpgradeSpeed.GetComponent<Button>();
        _UpgradeDEF.GetComponent<Button>();
        _UpgradeHP.GetComponent<Button>();

        _ExitPlayerInfo.onClick.AddListener(PlayerInfoWindow_Exit_OnClick);
        _UpgradeATK.onClick.AddListener(PlayerInfoWindow_UpgradeATK_OnClick);
        _UpgradeSpeed.onClick.AddListener(PlayerInfoWindow_UpgradeSpeed_OnClick);
        _UpgradeDEF.onClick.AddListener(PlayerInfoWindow_UpgradeDEF_OnClick);
        _UpgradeHP.onClick.AddListener(PlayerInfoWindow_UpgradeHP_OnClick);
    }

    void InventorySelectWindowInits()
    {
        _ExitInventorySelect.GetComponent<Button>();

        _ExitInventorySelect.onClick.AddListener(InventorySelectWindow_Exit_OnClick);
    }

    #region UI Events

    void Skills_OnClick()
    {
        Debug.Log("Clicked Skills");
    }

    void PlayerInfo_OnClick()
    {
        Debug.Log("Clicked PlayerInfo");

        _DicUIWindows["PlayerInfoWindow"].SetActive(true);
    }

    void InventoryBags_OnClick()
    {
        Debug.Log("Clicked InventoryBags");

        _DicUIWindows["InventorySelectWindow"].SetActive(true);
    }

    void Settings_OnClick()
    {
        Debug.Log("Clicked Settings");
    }

    #endregion

    #region PlayerInfoWindow Events

    void PlayerInfoWindow_Exit_OnClick()
    {
        Debug.Log("Exiting PlayerInfo Window");

        _DicUIWindows["PlayerInfoWindow"].SetActive(false);
    }

    void PlayerInfoWindow_UpgradeATK_OnClick()
    {
        Debug.Log("Upgrading ATK");
    }

    void PlayerInfoWindow_UpgradeSpeed_OnClick()
    {
        Debug.Log("Upgrading Speed");
    }

    void PlayerInfoWindow_UpgradeDEF_OnClick()
    {
        Debug.Log("Upgrading DEF");
    }

    void PlayerInfoWindow_UpgradeHP_OnClick()
    {
        Debug.Log("Upgrading HP");
    }

    #endregion

    #region InventorySelectWindow Events

    void InventorySelectWindow_Exit_OnClick()
    {
        Debug.Log("Exiting InventorySelect Window");

        _DicUIWindows["InventorySelectWindow"].SetActive(false);
    }

    #endregion
}
