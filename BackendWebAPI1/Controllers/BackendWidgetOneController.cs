[Route("api/[controller]")]
[ApiController]
public class BackendWidgetOneController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<BackendWidgetOneDTO> GetAllWidgets()
    {
        
    }    

    [HttpGet({id})]
    public async Task<ActionResult> GetWidget(GUID id)
    {
        
    }

    [HttpPost]
    public async Task<ActionResult> CreateWidget([FromBody] BackendWidgetOneDTO backendWidgetOneDTO)
    {
        return CreatedAtAction()
    }

    [HttpPut({id})]
    public async Task<ActionResult> UpdateWidget(GUID id)
    {

    }
}