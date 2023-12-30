using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ui : MonoBehaviour
{


    [SerializeField] private GameObject pnl_grabCharm;
    [SerializeField] private GameObject pnl_jumpCharm;
    [SerializeField] private GameObject pnl_loveCharm;
    [SerializeField] private GameObject pnl_MainMenu;
    [SerializeField] private GameObject pnl_options;
    [SerializeField] private GameObject crossHair;
    [SerializeField] private TMP_Text txt_info;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject vc_mainMenu;

    private bool somethingOpen = false;



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!somethingOpen)
                OpenOptions();
        }
    }


    public void BtnStart_onClick()
    {
        player.SetActive(true);
        vc_mainMenu.SetActive(false);
        CloseMenues();

    }



    public void OpenGrabCharmCollected()
    {
        PlayerManager.CanMove = false;
        somethingOpen = true;
        pnl_grabCharm.SetActive(true);
        crossHair.SetActive(false);
    }

    public void OpenJumpCharmCollected()
    {
        PlayerManager.CanMove = false;
        somethingOpen = true;
        crossHair.SetActive(false);
        pnl_jumpCharm.SetActive(true);

    }


    public void OpenLoveCharmCollected()
    {
        PlayerManager.CanMove = false;
        somethingOpen = true;
        pnl_loveCharm.SetActive(true);
        crossHair.SetActive(false);

    }

    public void OpenOptions()
    {
        somethingOpen = true;
        PlayerManager.CanMove = false;
        pnl_options.SetActive(true);
        crossHair.SetActive(false);
    }


    public void CloseMenues()
    {
        if (player.activeSelf)// check if game starts
        {
            PlayerManager.CanMove = true;
            crossHair.SetActive(true);
            pnl_MainMenu.SetActive(false);
        }

        pnl_grabCharm.SetActive(false);
        pnl_jumpCharm.SetActive(false);
        pnl_loveCharm.SetActive(false);
        pnl_options.SetActive(false);

        somethingOpen = false;

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
