using System;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages
{
    public class IndexBase : PageBase
    {

        public bool Toggle = false;

        protected async Task Submit()
        {
            Toggle = !Toggle;
            Console.WriteLine("Submit...");
        }

    }
}
