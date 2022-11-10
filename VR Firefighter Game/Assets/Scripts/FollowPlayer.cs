using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject object;

    private GameObject[] player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        fixerJoueur();
        //object.transform.foward
    }

    Vector3 getPlayerDirection()
    {
        if (player.Length < 2)
        {
            Vector3 _player_pose = player[0].transform.position;
            Vector3 _object_pose = object.transform.position;
            Vector3 _direction = _object_pose - _player_pose;
            return _direction;
        }
        else
        {
            return null;
        }
    }

    void fixerJoueur()
    {
        Vector3 _direction = getPlayerDirection();
        if (_direction != null)
        {
            object.transform.rotation = _direction;
        }
    }
}
