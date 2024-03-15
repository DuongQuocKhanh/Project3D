using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPause : BasePopup
{
    public override void Init()
    {
        base.Init();
        
    }

    public override void Show(object data)
    {
        base.Show(data);
       
    }

    public override void Hide()
    {
        base.Hide();
    }

    public void OnClickHomeButton()
    {
        //if (UIManager.HasInstance)
        //{
        //    UIManager.Instance.ShowScreen<ScreenHome>();
        //}
        Hide();
        GameManager.Instance.RestartGame();
        Time.timeScale = 1f;
        
    }

    public void OnClickCloseButton()
    {
        Hide();
        Time.timeScale = 1f;
    }

}
