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
    }

    protected virtual void Complete()
    {
        miniHook.Complete();
        gameObject.SetActive(false);

    }
}
