using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    public GameObject rect_box_Mid_1;
    public GameObject rect_box_Left_1;
    public GameObject rect_box_right_1;
    public GameObject rect_box_Last;


    public Transform Congress_1;
    public float animTime;
    public Ease animEase;

    public Transform BabyLeft;
    public float BabyAnimLeft;

    public Transform BabyRight;
    public float BabyAnimRight;

    //rect box
    //public Transform rect_box_Mid;
    public Transform rect_box_Left;
    public float rect_box_Left_Anim;
    public Transform rect_box_right;
    public float rect_box_right_Anim;

    public GameObject Morelevels;

    public GameObject hand;
    public GameObject dot_line;
    public GameObject Text;

    public GameObject Particle;

    public void Start()
    {
        Particle.SetActive(false);
    }
    public void Update()
    {
       
        if (FirstDrop.locked)
        {
            rect_box_Left
                .DOMove(new Vector2(-0.87f, -2.99f), rect_box_Left_Anim);
            rect_box_right
                .DOMove(new Vector2(1.08f, -2.99f), rect_box_right_Anim);
            rect_box_Mid_1.SetActive(false);
            hand.SetActive(false);
            dot_line.SetActive(false);
            Text.SetActive(false);
        }
        if(SecondDrop.locked)
        {
            rect_box_Left_1.SetActive(false);
            rect_box_right_1.SetActive(false);
            rect_box_Last.SetActive(true);
        }

        if(FirstDrop.locked && SecondDrop.locked && ThirdDrop.locked)
        {
            Particle.SetActive(true);
            Congress_1
                .DOMove(new Vector2(0f, 0.81f), animTime)
                .SetEase(animEase);
            BabyLeft
                .DOMove(new Vector2(-1.28f, -0.33f), BabyAnimLeft);
            BabyRight
                .DOMove(new Vector2(1.28f, -0.3000002f), BabyAnimRight);

            rect_box_Mid_1.SetActive(false);
            rect_box_Left_1.SetActive(false);
            rect_box_right_1.SetActive(false);
            rect_box_Last.SetActive(false);
            Morelevels.SetActive(true);

            Particle.SetActive(true);

        }   
    }
}
