using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Inheritance-t hasznalunk, hogy elegansabban nezzen ki es ne kelljen minden egyes controller fole odairjuk az Attribute-okat.
    // Controllerek kotelezoen a ControllerBase-bol derivalnak
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}