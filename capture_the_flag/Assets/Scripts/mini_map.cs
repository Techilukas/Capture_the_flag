using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_map : MonoBehaviour
{
    public Camera cam;
    public Transform follow;
    public Transform player;

    const float scale = 0.02f; 

    Vector3 player_pos;
    Vector3 stupid = new Vector3(.5f, .25f, 0);

    // Update is called once per frame
    void Update()
    {
        player_pos = cam.ScreenToWorldPoint(follow.position);

        player_pos *= scale;

        player_pos += transform.position+stupid;

        player.position = player_pos;
    }
}
