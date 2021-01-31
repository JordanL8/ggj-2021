using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideItem : MonoBehaviour
{

    public void HideButt(Button butt)
    {
        butt.gameObject.SetActive(false);
    }
}
