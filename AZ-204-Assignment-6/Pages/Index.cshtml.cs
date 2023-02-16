using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Graph;

namespace AZ_204_Assignment_6.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly GraphServiceClient graphClient;

        public string DisplayName;
        public string UserPrincipalName;


        public IndexModel(ILogger<IndexModel> logger, GraphServiceClient graphClient)
        {
            this.logger = logger;
            this.graphClient = graphClient;
        }

        public async Task OnGet()
        {
            if (User?.Identity?.IsAuthenticated == false)
            {
                return;
            }

            var myData = await graphClient.Me
                .Request()
                .GetAsync();

            UserPrincipalName = myData.UserPrincipalName;
            DisplayName = myData.DisplayName;
        }
    }
}