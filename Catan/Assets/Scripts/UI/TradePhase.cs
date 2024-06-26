using Catan.GameManagement;
using Catan.Players;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Catan.ResourcePhase;
using Catan.TradePhase;

namespace Catan.UI
{

    public class TradePhase : MonoBehaviour
    {
        public GameObject playerSelect;
        public GameObject tradeWindow;
        public GameObject portTradeWindow;
        public GameObject tradeButton;
        public GameObject nextButton;
        public GameObject offerWindow;
        public GameObject acceptedBox;
        public TextMeshProUGUI acceptedText;
        public GameManager gm;

        public Player selectedPlayer;

        private bool result = false;


        public void OpenPlayerSelectWindow()
        {
            CloseTradeWindows();
            playerSelect.GetComponent<TradePhasePlayerSelect>().Initialize();
            playerSelect.SetActive(true);
        }
        public void OpenTradeWindow()
        {
            CloseTradeWindows();
            tradeWindow.GetComponent<TradePhaseTradeWindow>().Initialize();
            tradeWindow.SetActive(true);
        }
        public void OpenOfferWindow()
        {
            CloseTradeWindows();
            offerWindow.SetActive(true);
        }
        public void ShowOffer(Player p1, Player p2, Resource[] p1Offer, Resource[] p2Offer)
        {
            offerWindow.GetComponent<TradePhaseTradeOffer>().Initialize(p1, p2, p1Offer, p2Offer);
            OpenOfferWindow();
        }
        public void Offer(Player p1, Player p2, Resource[] p1Offer, Resource[] p2Offer)
        {
            Trader.Request(p1, p2, p1Offer, p2Offer);
        }

        public void ConfirmResult(bool res)
        {
            result = res;
        }

        public void OpenPortTradeWindow()
        {
            CloseTradeWindows();
            portTradeWindow.GetComponent<TradePhasePortTrade>().Initialize(gm.currentPlayer);
            portTradeWindow.SetActive(true);
        }

        public void ShowTradeButton()
        {
            CloseTradeWindows();
            EnableTradeButton();
        }

        public void EnableTradeButton()
        {
            tradeButton.SetActive(true);
            nextButton.SetActive(true);
        }
        public void ShowTradeResultWindow(bool tradeResult)
        {
            CloseTradeWindows();
            if (tradeResult)
            {
                acceptedText.text = "Trade Accepted!";
            }
            else
            {
                acceptedText.text = "Trade Rejected.";
            }
            acceptedBox.SetActive(true);
        }
        public void CloseTradeWindows()
        {
            playerSelect.SetActive(false);
            tradeWindow.SetActive(false);
            portTradeWindow.SetActive(false);
            tradeButton.SetActive(false);
            nextButton.SetActive(false);
        }

        public void Start()
        {
            playerSelect.GetComponent<TradePhasePlayerSelect>().tradePhase = this;
            tradeWindow.GetComponent<TradePhaseTradeWindow>().tradePhase = this;
            portTradeWindow.GetComponent<TradePhasePortTrade>();
        }
    }
}