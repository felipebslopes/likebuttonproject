using Microsoft.OpenApi.Models;

namespace Like.WebApi
{
    internal class Info : OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public object Contact { get; set; }
    }
}