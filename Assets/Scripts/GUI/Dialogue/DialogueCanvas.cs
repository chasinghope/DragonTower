using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCanvas : MonoBehaviour
{
    DiaComponent diaComponent;

    public Transform Content;
    public DialogueTemplateView otherTemplateView;
    public DialogueTemplateView selfTemplateView;

    private RectTransform refreshRect;
    // Start is called before the first frame update
    void Start()
    {
        refreshRect = Content.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            diaComponent = Transform.FindObjectOfType<DiaComponent>();
            CreateDiaContent(diaComponent.startDiaNode);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (diaComponent == null)
                return;
            DiaNode diaNode = diaComponent.FindNextNode(0);
            if (diaNode)
            {
                CreateDiaContent(diaNode);
            }
        }
    }

    /// <summary>
    /// 打印对话内容
    /// </summary>
    /// <param name="startDiaNode"></param>
    private void PrintDiaContent(DiaNode diaNode)
    {
        Debug.Log(diaNode.Text);

        if(diaNode.Type == DiaType.PersonalityAdjudication)
        {
            for (int i = 0; i < diaNode.Output.Count; i++)
            {
                if (!string.IsNullOrEmpty(diaNode.Output[i].Answer))
                    Debug.Log($"{i+1}: {diaNode.Output[i].Answer}");
            }
        }

    }


    private void CreateDiaContent(DiaNode diaNode)
    {
        DialogueTemplateView other = Instantiate(otherTemplateView.gameObject).GetComponent<DialogueTemplateView>();
        other.transform.SetParent(Content);
        other.SpeakerImg.sprite = diaNode.Icon;
        other.NameText.text = diaNode.Name;
        other.ContentText.text = diaNode.Text;
        other.gameObject.SetActive(true);

        other.RefreshLayout();
        LayoutRebuilder.ForceRebuildLayoutImmediate(refreshRect);

        if (diaNode.Type == DiaType.PersonalityAdjudication)
        {
            for (int i = 0; i < diaNode.Output.Count; i++)
            {
                if (!string.IsNullOrEmpty(diaNode.Output[i].Answer))
                    Debug.Log($"{i + 1}: {diaNode.Output[i].Answer}");
            }
        }

    }


}
