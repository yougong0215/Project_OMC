using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScene : MonoBehaviour
{
    public void MoveToScene()
    {
        SceneController.Instance.MoveLevel();
    }
}
