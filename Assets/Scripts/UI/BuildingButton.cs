using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
    [SerializeField] private BuildingData buildingData;

    [SerializeField]  private Image buttonImage;

    private void Start()
    {
        BuildButtonManager.OnButtonPressed += UpdateButtonState;

        buttonImage.sprite = buildingData.icon;
    }

    public void SelectBuilding()
    {
        if (BuildManager.Instance.GetBuildingData() == buildingData)
        {
            BuildManager.Instance.SelectBuilding(null);
            BuildButtonManager.Instance.SetSelectedButton(null);
            SideMenuManager.Instance.SetDescription(null, null);
        }
        else
        {
            BuildManager.Instance.SelectBuilding(buildingData);
            BuildButtonManager.Instance.SetSelectedButton(this);
            SideMenuManager.Instance.SetDescription(buildingData.icon, buildingData.description);
        }

        BuildButtonManager.Instance.ButtonPressed();
    }

    private void UpdateButtonState()
    {
        if (BuildButtonManager.Instance.GetSelectedBuildButton() == this)
        {
            GetComponent<Image>().color = BuildButtonManager.Instance.GetSelectedColor();
        }
        else
        {
            GetComponent<Image>().color = GetComponent<Button>().colors.normalColor;
        }
    }
}
