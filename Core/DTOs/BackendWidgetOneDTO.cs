public class BackendWidgetOneDTO
{
    public int A { get; set; }
    public string B { get; set; }

    public static BackendWidgetOneDTO MapFrom(BackendWidgetOne backendWidgetOne)
    {
        return new BackendWidgetOneDTO {
            A = backendWidgetOne.Value,
            B = backendWidgetOne.Name
        };
    }
}