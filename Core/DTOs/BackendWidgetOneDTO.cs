public class BackendWidgetOneDTO
{
    public int Value { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// Allows an implicit cast of a BackendWidgetOne object to a BackendWidgetOneDTO object
    /// </summary>
    /// <param name="backendWidgetOne"></param>
    public static implicit operator BackendWidgetOneDTO(BackendWidgetOne backendWidgetOne)
    {
        return new BackendWidgetOneDTO {
            Value = backendWidgetOne.Value,
            Name = backendWidgetOne.Name
        };
    }

    // public static BackendWidgetOneDTO MapFrom(BackendWidgetOne backendWidgetOne)
    // {
    //     return new BackendWidgetOneDTO {
    //         Value = backendWidgetOne.Value,
    //         Name = backendWidgetOne.Name
    //     };
    // }
}