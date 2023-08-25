public class Widget
{
    /// <summary>
    /// A GUID unique to the widget
    /// </summary>
    public GUID guid { get; set; }
    /// <summary>
    /// A name for the Widget
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The Widget's type
    /// </summary>
    public string Type => this.Type.Name;
}