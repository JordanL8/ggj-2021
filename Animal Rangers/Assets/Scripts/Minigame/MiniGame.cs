using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    private MiniGameHook miniHook;

    public virtual void StartMiniGame(MiniGameHook miniGameHook)
    {
        miniHook = miniGameHook;
        gameObject.SetActive(true);

        RadarManager.Instance.gameObject.SetActive(false);
        MinimapManager.Instance.gameObject.SetActive(false);
    }

    protected virtual void Complete()
    {
        miniHook.Complete();
        gameObject.SetActive(false);

        RadarManager.Instance.gameObject.SetActive(true);
        MinimapManager.Instance.gameObject.SetActive(true);
    }
}
