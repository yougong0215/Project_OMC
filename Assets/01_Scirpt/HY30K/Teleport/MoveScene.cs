using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScene : MonoBehaviour
{
    public void MoveToScene(string scene)
    {
        SceneController.Instance.MoveLevel(scene);
    }
}
