using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Action OnRoadPlacement, OnHousePlacement, OnSpecialPlacement, OnBigStructurePlacement, OnPlayerHousePlacement;
    public Button placeRoadButton, placeHouseButton, placeSpecialButton, placeBigStructureButton, placePlayerHouse;


    public Color outlineColor;
    public List<Button> buttonList;

    private int _indexUnlockedButton;

    public int IndexUnlockedButton { get => _indexUnlockedButton; set { _indexUnlockedButton = value; }}


    public void Initialize()
    {
        buttonList = new List<Button> { placePlayerHouse, placeSpecialButton, placeBigStructureButton, placeRoadButton, placeHouseButton };

        BlockButtons();

        placeRoadButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeRoadButton);
            OnRoadPlacement?.Invoke();
        });
        placeHouseButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeHouseButton);
            OnHousePlacement?.Invoke();

        });
        placeSpecialButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeSpecialButton);
            OnSpecialPlacement?.Invoke();

        });
        placeBigStructureButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeBigStructureButton);
            OnBigStructurePlacement?.Invoke();

        });
        placePlayerHouse.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placePlayerHouse);
            OnPlayerHousePlacement?.Invoke();

        });
    }

    public void BlockButtons()
    {
        IndexUnlockedButton++;

        switch (IndexUnlockedButton)
        {
            case 1:
                placePlayerHouse.interactable = true;
                placeSpecialButton.interactable = false;
                placeBigStructureButton.interactable = false;
                placeRoadButton.interactable = false;
                placeHouseButton.interactable = false;
                break;
            case 2:
                placePlayerHouse.interactable = false;
                placeSpecialButton.interactable = true;
                placeBigStructureButton.interactable = false;
                placeRoadButton.interactable = false;
                placeHouseButton.interactable = false;
                break;
            case 3:
                placePlayerHouse.interactable = false;
                placeSpecialButton.interactable = false;
                placeBigStructureButton.interactable = true;
                placeRoadButton.interactable = true;
                placeHouseButton.interactable = true;
                break;
            case 4:
                placePlayerHouse.interactable = false;
                placeSpecialButton.interactable = false;
                placeBigStructureButton.interactable = false;
                placeRoadButton.interactable = true;
                placeHouseButton.interactable = true;
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
        foreach (Button button in buttonList)
        {
            button.GetComponent<Outline>().enabled = false;
        }
    }
}
