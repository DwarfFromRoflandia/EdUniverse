using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class UIController : MonoBehaviour
{
    public Action OnRoadPlacement, OnHousePlacement, OnSpecialPlacement, OnBigStructurePlacement, OnPlayerHousePlacement;
    public Button placeRoadButtonForCityOwner, placeHouseButtonForCityOwner, placeSpecialButtonForCityOwner, placeBigStructureButtonForCityOwner, placePlayerHouseButtonForCityOwner;
    public Button placeRoadButtonForCityGuest, placeHouseButtonForCityGuest;

    [SerializeField] private GameObject _cityOwnerPanel;
    [SerializeField] private GameObject _cityGuestPanel;

    public Color outlineColor;
    public List<Button> ButtonsListForOwnerCity;
    public List<Button> ButtonsListForGuestCity;

    private int _indexUnlockedButton;

    public int IndexUnlockedButton { get => _indexUnlockedButton; set { _indexUnlockedButton = value; }}


    public void Initialize()
    {


        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                _cityOwnerPanel.SetActive(true);
                _cityGuestPanel.SetActive(false);        
            }
            else
            {
                _cityGuestPanel.SetActive(true);
                _cityOwnerPanel.SetActive(false);        
            }
        }

        placeRoadButtonForCityOwner = ButtonsListForOwnerCity[3];
        placeHouseButtonForCityOwner = ButtonsListForOwnerCity[4];
        placeSpecialButtonForCityOwner = ButtonsListForOwnerCity[1];
        placeBigStructureButtonForCityOwner = ButtonsListForOwnerCity[2];
        placePlayerHouseButtonForCityOwner = ButtonsListForOwnerCity[0];

        BlockButtons();

        placeRoadButtonForCityOwner.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeRoadButtonForCityOwner);
            OnRoadPlacement?.Invoke();
        });
        placeHouseButtonForCityOwner.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeHouseButtonForCityOwner);
            OnHousePlacement?.Invoke();

        });
        placeSpecialButtonForCityOwner.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeSpecialButtonForCityOwner);
            OnSpecialPlacement?.Invoke();

        });
        placeBigStructureButtonForCityOwner.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeBigStructureButtonForCityOwner);
            OnBigStructurePlacement?.Invoke();

        });
        placePlayerHouseButtonForCityOwner.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placePlayerHouseButtonForCityOwner);
            OnPlayerHousePlacement?.Invoke();

        });

        placeRoadButtonForCityGuest = ButtonsListForGuestCity[0];
        placeHouseButtonForCityGuest = ButtonsListForGuestCity[1];

        placeRoadButtonForCityGuest.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeRoadButtonForCityGuest);
            OnRoadPlacement?.Invoke();
        });

        placeHouseButtonForCityGuest.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeHouseButtonForCityGuest);
            OnHousePlacement?.Invoke();

        });

    }



    public void BlockButtons()
    {
        IndexUnlockedButton++;

        switch (IndexUnlockedButton)
        {
            case 1:
                placePlayerHouseButtonForCityOwner.interactable = true;
                placeSpecialButtonForCityOwner.interactable = false;
                placeBigStructureButtonForCityOwner.interactable = false;
                placeRoadButtonForCityOwner.interactable = false;
                placeHouseButtonForCityOwner.interactable = false;
                break;
            case 2:
                placePlayerHouseButtonForCityOwner.interactable = false;
                placeSpecialButtonForCityOwner.interactable = true;
                placeBigStructureButtonForCityOwner.interactable = false;
                placeRoadButtonForCityOwner.interactable = false;
                placeHouseButtonForCityOwner.interactable = false;
                break;
            case 3:
                placePlayerHouseButtonForCityOwner.interactable = false;
                placeSpecialButtonForCityOwner.interactable = false;
                placeBigStructureButtonForCityOwner.interactable = true;
                placeRoadButtonForCityOwner.interactable = true;
                placeHouseButtonForCityOwner.interactable = true;
                break;
            case 4:
                placePlayerHouseButtonForCityOwner.interactable = false;
                placeSpecialButtonForCityOwner.interactable = false;
                placeBigStructureButtonForCityOwner.interactable = false;
                placeRoadButtonForCityOwner.interactable = true;
                placeHouseButtonForCityOwner.interactable = true;
                break;
            default:
                break;
        }
    }

    private void ModifyOutline(Button button)
    {
        var outline = button.GetComponent<Outline>();
        outline.effectColor = outlineColor; 
        outline.enabled = true;
    }

    private void ResetButtonColor()
    {
        foreach (Button button in ButtonsListForOwnerCity)
        {
            button.GetComponent<Outline>().enabled = false;
        }
    }
}
