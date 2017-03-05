using UnityEngine;
using System.Collections;

public class EnvMenuToggler : MonoBehaviour
{
    private GameController GameCon;
    public GameObject[] Environments;
    // Use this for initialization
    void Start()
    {
        GameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void Toggle()
    {
        GameCon.EnvMenuOpen = !GameCon.EnvMenuOpen;
        foreach (GameObject Env in Environments)
        {
            Env.SetActive(GameCon.EnvMenuOpen);
        }
    }
}