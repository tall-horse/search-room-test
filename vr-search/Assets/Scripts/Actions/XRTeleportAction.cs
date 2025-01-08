using System.Collections.Generic;
using System.Linq;
using BlueTea.Core.ActionCategories;
using BlueTea.Core.Interactables;
using BlueTea.Core.Interactables.Utility;
using Unity.XR.CoreUtils;
using VirtualStudio.Actions;
using VirtualStudio.Models;

[Action("0.6.0", "Teleport the player to a designated area")]
public class XRTeleportAction : Action
{
    public override string ActionCategory => new LevelFlow().Name;
    public string[] Targets { get; set; }
    public string ClickMode { get; set; }
    public List<Interactable> Interactables;
    public override void Initialize()
    {
        base.Initialize();
        Interactables = new List<Interactable>();

        if (Targets.Contains("PlayerTeleporter"))
        {
            Interactables = InteractablesUtility.FindAllInteractablesWithTags(new PlayerTeleporterTag());
        }
    }

    public override void Execute()
    {
        foreach (Interactable interactable in Interactables)
        {
            interactable.GetComponent<PlayerTeleporter>().TeleportToStart();
            OnFinished();
        }
    }

    public ActionPropertyInformation TargetsInfo() =>
            new ActionPropertyInformation
            {
                Description = "The teleporter for player",
                Choices = new List<ActionPropertyChoice>()
                {
                    new ActionPropertyChoice(new string[] {typeof(PlayerTeleporterTag).FullName}, ChoiceType.Tag),
                    new ActionPropertyChoice(new string[] {"All"}, ChoiceType.String),
                },
                DefaultValue = new List<string>
                {
                    InteractablesUtility.FindAllInteractablesIdsWithTags(new PlayerTeleporterTag()).FirstOrDefault()
                },
                Type = ActionPropertyType.Interactables
            };

    public ActionPropertyInformation ClickModeInfo() =>
        new ActionPropertyInformation
        {
            Description = "Should player teleport to any or all of the listed targets",
            DefaultValue = "Any",
            Choices = new List<ActionPropertyChoice>()
            {
                    new ActionPropertyChoice(new string[] {"Any", "All"}, ChoiceType.String)
            },
            Type = ActionPropertyType.String
        };
}
