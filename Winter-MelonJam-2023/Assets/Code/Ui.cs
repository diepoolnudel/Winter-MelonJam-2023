using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ui : MonoBehaviour
{


    [SerializeField] private GameObject pnl_grabCharm;
    [SerializeField] private GameObject pnl_jumpCharm;
    [SerializeField] private GameObject pnl_loveCharm;
    [SerializeField] private TMP_Text txt_info;





    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenues();
        }
    }


    public void OpenGrabCharmCollected()
    {
        PlayerManager.CanMove = false;
        pnl_grabCharm.SetActive(true);

    }

    public void OpenJumpCharmCollected()
    {
        PlayerManager.CanMove = false;
        pnl_jumpCharm.SetActive(true);

    }


    public void OpenLoveCharmCollected()
    {
        PlayerManager.CanMove = false;
        pnl_loveCharm.SetActive(true);

    }


    public void CloseMenues()
    {
        PlayerManager.CanMove = true;

        pnl_grabCharm.SetActive(false);
        pnl_jumpCharm.SetActive(false);
        pnl_loveCharm.SetActive(false);

    }


    public void ShowInfoText(string text)
    {
        txt_info.text = text;
        txt_info.gameObject.SetActive(true);

    }

    public void HideInfoText()
    {
        txt_info.gameObject.SetActive(false);
    }


}
