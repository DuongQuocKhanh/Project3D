using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupHelp : BasePopup
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

  

    public void OnClickCloseButton()
    {
        Hide();
    }

   
}
