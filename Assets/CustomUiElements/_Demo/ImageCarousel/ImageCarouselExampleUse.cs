using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCarouselExampleUse : MonoBehaviour
{
    public GameObject OpenCarouselButton;
    public GameObject ImageCarouselParent;
    public GameObject CloseCarouselButton;
	
    public void OpenImageCarousel()
    {
        ImageCarouselParent.SetActive(true);
        CloseCarouselButton.SetActive(true);
    }

    public void CloseImageCarousel()
    {
        ImageCarouselParent.SetActive(false);
        CloseCarouselButton.SetActive(false);
    }
}
