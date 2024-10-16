using BlueTea.Core.Tags;
using UnityEngine;

public class DrawerHandleTag : ITag
{
    public bool Validate(TagComponent tagComponent)
    {
        if (tagComponent.CompareTag("Drawer Handle"))
                return true;

            return tagComponent.CompareTag("Drawer Handle");
    }

    public string ValidationErrorMessage()
    {
        return $"Drawer Handle tag is not assigned to this {nameof(GameObject)}";
    }
}
