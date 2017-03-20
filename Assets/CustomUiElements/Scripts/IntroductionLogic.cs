using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionLogic : MonoBehaviour
{
    /*
    // Only show video and call CRM the first time this scene is loaded. Other times we skip these actions
    public static bool FirstTime = true;

    public GameObject SideMenuCanvasParent;

    void Start()
    {

    
            if (!FirstTime)
            {
                Destroy(SideMenuCanvasParent);
            }
            ShowProjectSelection();
        FirstTime = false;
    }
        


    void ShowProjectSelection()
    {
        // SideMenuCanvasParent gets deleted if it's not the first time
        GameObject originalSideMenu = GameObject.FindGameObjectWithTag("OriginalSideMenu");
        if (originalSideMenu == null)
        {
            SideMenuCanvasParent.SetActive(true);
            SideMenuCanvasParent.GetComponent<SideMenuLogic>().BackgroundMusicOn();
        }
        else
        {
            originalSideMenu.GetComponent<SideMenuLogic>().ForceHideMenu();
            SideMenuCanvasParent.GetComponent<SideMenuLogic>().BackgroundMusicOn();
        }
            
        SelectionCanvas.SetActive(true);
        StartCoroutine(DissolveBlockerImage());
    }
    
    IEnumerator DissolveBlockerImage()
    {
        while (blockerImageAlpha > 0.05f)
        {
            blockerImageAlpha = blockerImageAlpha - 0.008f;
            if (BlockerImage != null)
            {
                BlockerImage.color = new Color(0, 0, 0, blockerImageAlpha);
            }
            yield return null;
        }
        blockerImageAlpha = 0f;
        if (BlockerImage != null)
        {
            BlockerImage.color = new Color(0, 0, 0, blockerImageAlpha);
        }
        yield break;
    }
    */
}