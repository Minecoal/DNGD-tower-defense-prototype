using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SideMenuManager : GenericSingleton<SideMenuManager>
{
    private Animator anim;

    [SerializeField] private GameObject hideButton;

    [Header("Description")]
    [SerializeField] private Image descriptionImage;
    [SerializeField] private TextMeshProUGUI descriptionTxt;

    private bool isExtended = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDescription(Sprite image, string description)
    {
        if(image==null || description == null)
        {
            descriptionImage.sprite = null;
            descriptionTxt.text = "";
        }
        descriptionImage.sprite = image;
        descriptionTxt.text = description;
    }

    public void HideButtonPressed()
    {
        if (isExtended)
        {
            isExtended = false;
            
        }
        else
        {
            isExtended = true;
        }

        anim.SetBool("extended", isExtended);
    }
}
