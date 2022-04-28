using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] characters;
    public List<GameObject> charactersOnScreen;


    private void Start()
    {
        characters = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        FindGameObjectsOnScreen();
    }

    private void FindGameObjectsOnScreen()
    {
        foreach (var character in characters)
        {
            if (character.GetComponentsInChildren<Renderer>(true)[0].enabled)
            {
                if (charactersOnScreen.IndexOf(character) == -1)
                {
                    charactersOnScreen.Add(character);
                }
            }
        }
    }

    private void Fight()
    {
        if (charactersOnScreen.Count == 2)
        {
            if (charactersOnScreen[0].GetComponent<Personagem>().forca > charactersOnScreen[1].GetComponent<Personagem>().forca)
            {
                charactersOnScreen[0].GetComponentInChildren<Animator>().Play("Atack");
                charactersOnScreen[1].GetComponentInChildren<Animator>().Play("Death");
                return;
            }
            charactersOnScreen[0].GetComponentInChildren<Animator>().Play("Death");
            charactersOnScreen[1].GetComponentInChildren<Animator>().Play("Atack");
            return;
        }
        if (charactersOnScreen.Count == 1)
        {
            charactersOnScreen[0].GetComponentInChildren<Animator>().Play("Idle");
            return;
        }
    }
}
