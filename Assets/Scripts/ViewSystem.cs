using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ViewSystem : MonoBehaviour
{
    [Header("REFERENCE")]
    public TextMeshProUGUI txtTitle;
    public TextMeshProUGUI txtComments;
    public TextMeshProUGUI txtAction;

    public Image imgPhoto;
    public Image imgLeftArrow;
    public Image imgRightArrow;


    public GameObject actionBoton;

    Project currentProject;
    int currentPhoto;

    public void newProject( Project _project)
    {
        currentProject = _project;
        currentPhoto = 0;

        txtComments.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        txtTitle.text = currentProject.Title;
        txtComments.text = currentProject.Comment;

        if (currentProject.canPlay){
            actionBoton.SetActive(true);
            txtAction.text = currentProject.botonName;
        }else
            actionBoton.SetActive(false);

        updatePhoto();
    }



    public void NextPhoto(){
        if(currentPhoto < currentProject.Photos.Length - 1){
            currentPhoto++;
            updatePhoto();
        }
    }

    public void PrevPhoto(){
        if (currentPhoto > 0){
            currentPhoto--;
            updatePhoto();
        }
    }



    void updatePhoto(){
        imgPhoto.sprite = currentProject.Photos[currentPhoto];
        imgPhoto.GetComponent<AspectRatioFitter>().aspectRatio = currentProject.Photos[currentPhoto].rect.width / currentProject.Photos[currentPhoto].rect.height;

        if (currentPhoto == 0){
            imgLeftArrow.enabled = false;
            imgRightArrow.enabled = true;
        }
        else if (currentPhoto >= currentProject.Photos.Length - 1){
            imgLeftArrow.enabled = true;
            imgRightArrow.enabled = false;
        }else{
            imgLeftArrow.enabled = true;
            imgRightArrow.enabled = true;   
        }
    }


    public void OpenLink()
    {

        Application.OpenURL(currentProject.projectLink);

    }

}