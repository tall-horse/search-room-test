using System.Collections.Generic;
using System.Linq;
using BlueTea.Core.ActionCategories;
using BlueTea.Core.Interactables;
using BlueTea.Core.Interactables.Utility;
using BlueTea.Core.Tags;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using VirtualStudio.Actions;
using VirtualStudio.Models;

[Action("0.4.0", "Wait for the player in XR to release the interactable")]
public class XRReleaseAction : Action
{
    public override string ActionCategory => new Interaction().Name;
    public string[] Targets { get; set; }
    public string ClickMode { get; set; }
    public List<Interactable> Interactables;
    public override void Initialize()
    {
        base.Initialize();
        Interactables = new List<Interactable>();

        if (Targets.Contains("All"))
        {
            Interactables = InteractablesUtility.FindAllInteractablesWithTags(new Clickable());
        }
        else
        {
            Interactables = InteractablesUtility.FindInteractablesWithNames(Targets);
        }
    }

    public override void Execute()
    {
        foreach (Interactable interactable in Interactables)
        {
            interactable.GetComponent<XRGrabInteractable>().selectExited.AddListener(SelectExited_Handler);
        }
    }

    private void SelectExited_Handler(SelectExitEventArgs selectExitEventArgs)
    {
        Debug.Log("Finish the XR Release Action"); OnFinished();
    }

    public ActionPropertyInformation TargetsInfo() =>
            new ActionPropertyInformation
            {
                Description = "The interactables to release in XR",
                Choices = new List<ActionPropertyChoice>()
                {
                    new ActionPropertyChoice(new string[] {typeof(Clickable).FullName}, ChoiceType.Tag),
                    new ActionPropertyChoice(new string[] {"All"}, ChoiceType.String),
                },
                DefaultValue = new List<string>
                {
                    InteractablesUtility.FindAllInteractablesIdsWithTags(new Clickable()).FirstOrDefault()
                },
                Type = ActionPropertyType.Interactables
            };

    public ActionPropertyInformation ClickModeInfo() =>
        new ActionPropertyInformation
        {
            Description = "Should the user release any or all of the listed targets",
            DefaultValue = "Any",
            Choices = new List<ActionPropertyChoice>()
            {
                    new ActionPropertyChoice(new string[] {"Any", "All"}, ChoiceType.String)
            },
            Type = ActionPropertyType.String
        };
}
