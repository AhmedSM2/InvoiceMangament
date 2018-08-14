using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace InvoiceManagementSystem.Models
{
    public class CustomActionFilter: ActionFilterAttribute, IActionFilter
    {
    }
}