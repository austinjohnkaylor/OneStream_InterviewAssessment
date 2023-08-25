public class BackendWidgetOne : Widget
{
    public int Value { get; set; }

    /// <summary>
    /// Allows an implicit cast of a BackendWidgetOneDTO object to a BackendWidgetOne object
    /// </summary>
    /// <param name="backendWidgetOne"></param>
    public static implicit operator BackendWidgetOne(BackendWidgetOneDTO backendWidgetOneDTO)
    {
        return new BackendWidgetOne {
            Value = backendWidgetOneDTO.Value,
            Name = backendWidgetOneDTO.Name
        };
    }
}