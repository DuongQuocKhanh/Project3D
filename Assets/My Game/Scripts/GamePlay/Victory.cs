using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {

        DOVirtual.DelayedCall(1f, () =>
        {
            if (UIManager.HasInstance)
            {
                string message = "Victory";
                UIManager.Instance.ShowPopup<PopupMessage>(data: message);
            }
        });
      


    }
}
