using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Project", menuName = "Project")]
public class Project : ScriptableObject
{
    public string Title;
    public Sprite[] Photos;
    [TextArea(5,30)]
    public string Comment;
    public bool canPlay;
    public string botonName;
    public string projectLink;
}
