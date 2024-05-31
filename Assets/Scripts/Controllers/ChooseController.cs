using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseController : MonoBehaviour
{
    public ChooseLabelController label;
    public GameController gameController;
    private RectTransform rectTransform;
    private Animator animator;
    public float labelWidth = -1;

    public GameObject skip;

    void Start()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetupChoose(ChooseScene scene)
    {
        DestroyLabels();
        animator.SetTrigger("Show");
        skip.SetActive(false);
        for (int index = 0; index < scene.labels.Count; index++)
        {
            ChooseLabelController newLabel = Instantiate(label.gameObject, transform).GetComponent<ChooseLabelController>();
            newLabel.Setup(scene.labels[index], CalculateLabelPosition(index, scene.labels.Count), this);
        }

        Vector2 size = rectTransform.sizeDelta;
        size.x = (scene.labels.Count + 2) * labelWidth;
        rectTransform.sizeDelta = size;
    }

    public void PerformChoose(StoryScene scene)
    {
        gameController.PlayScene(scene);
        animator.SetTrigger("Hide");
        skip.SetActive(true);
    }

    private float CalculateLabelPosition(int labelIndex, int labelCount)
    {
        if (labelIndex == 0)
        {
            return 300;

        }
        else
        {
            return -300;
        }

    }

    private void DestroyLabels()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }
}
