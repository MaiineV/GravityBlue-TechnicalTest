using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Model player;

    [SerializeField] private float _cameraSpeed;
    
    private void Awake()
    {
        player = GameManager.Instance.model;

        GameManager.Instance.updateManager.AddLateUpdate(OnLateUpdate);

        transform.position =
            new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    private void OnLateUpdate()
    {
        var dir = player.transform.position - transform.position;
        dir.z = 0;

        if (dir.magnitude > 3)
        {
            dir = dir.normalized * 3;
        }

        transform.position += dir * (_cameraSpeed * Time.deltaTime);
    }
}
