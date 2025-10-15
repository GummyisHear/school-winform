using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

public static class ControlHelper
{
    public static void ClearClickHandlers(Control ctrl)
    {
        FieldInfo clickEventField = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
        if (clickEventField == null) return;

        object clickEventKey = clickEventField.GetValue(null);

        PropertyInfo eventsProperty = typeof(Component).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
        EventHandlerList eventHandlerList = (EventHandlerList)eventsProperty.GetValue(ctrl);

        eventHandlerList.RemoveHandler(clickEventKey, eventHandlerList[clickEventKey]);
    }
}