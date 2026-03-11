using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    int mode;
    public void OnClickMode(int _mode)
    {
        mode = _mode;
    }

    public void OnClickLetsPlay()
    {
        GameManager.Instance.SetMode(mode);
        this.gameObject.SetActive(false);
    }
}
