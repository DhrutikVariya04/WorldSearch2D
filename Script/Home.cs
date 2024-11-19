using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.UIElements;
using System;

public class Home : MonoBehaviour
{
    private System.Random random = new System.Random();

    // For Colour Back :--
    private GameObject[,] TextStorage = new GameObject[7, 6];

    // For Colour Back :--   
    private Vector2Int startPos = Vector2Int.zero;

    private string[] AllStrings = { "HOME", "CARS", "APP", "GAME", "ROOM" };
    private bool Check = false;
    private string selectRowCollums = "";

    [SerializeField]
    GameObject Question, Alphabet, space, AnswerSaw;

    void Start()
    {
        for (int i = 0; i < AllStrings.Length; i++)
        {
            Question.transform.GetChild(i).GetComponent<Text>().text = AllStrings[i];
        }

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                TextStorage[i, j] = Instantiate(Alphabet, space.transform);
                TextStorage[i, j].GetComponent<Text>().text = "D";
                TextStorage[i, j].name = $"{i},{j}";
            }
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Check = true;

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // for select first text position and store it.
                string[] Pos = hit.collider.gameObject.name.Split(',');
                startPos = new Vector2Int(int.Parse(Pos[0]), int.Parse(Pos[1]));
                AnswerSaw.GetComponentInChildren<Text>().text = hit.transform.GetComponent<Text>().text;
                print(startPos);
            }
        }

        if (Check)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {

            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Check = false;

            for (int i = 0; i < AllStrings.Length; i++)
            {
                if (AllStrings[i] == AnswerSaw.GetComponentInChildren<Text>().text)
                {
                    print(AllStrings[i] + " == >> " + AllStrings[i].Length);
                }
                else
                {
                    //DeselectTexts();
                }

                AnswerSaw.GetComponentInChildren<Text>().text = "";
            }
            selectRowCollums = "";
        }
    }

    /*Take 5 Rendom String and select Randomly one of them(currefully all string select stap by stap)
     select string transfer into */
}
