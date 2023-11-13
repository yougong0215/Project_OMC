using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public void Open()
    {
        UIManager.Instance.SettingOpen();
    }

    public void Close()
    {
        UIManager.Instance.SettingClose();
    }
}
